using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JornalAberto2019.Models;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;

namespace JornalAberto2019.Controllers
{
    public class NoticiasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Noticias
        public ActionResult Index()
        {
            var noticias = db.Noticias.Include(n => n.AprovadaPor).Include(n => n.InseridaPor);
            return View(noticias.ToList());
        }

        // GET: Noticias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Noticias noticias = db.Noticias.Find(id);
            if (noticias == null)
            {
                return HttpNotFound();
            }
            return View(noticias);
        }

        // GET: Noticias/Create
        public ActionResult Create()
        {
            var noticia = new Noticias();
            noticia.ListaCategorias = new List<Categorias>();
            PopulateNoticiasCategorias(noticia);

            return View();
        }

        // POST: Noticias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NoticiaID,DataNoticia,Titulo,Descricao,Corpo")] Noticias noticia, string[] selectedCategories)
        {
            if (ModelState.IsValid)
            {
                // se forem selecionadas categorias
                if (selectedCategories != null)
                {
                    // nova lista de categorias
                    noticia.ListaCategorias = new List<Categorias>();
                    foreach (var categoria in selectedCategories)
                    {
                        var catToAdd = db.Categorias.Find(int.Parse(categoria));
                        noticia.ListaCategorias.Add(catToAdd);
                    }
                }

                // colocar automaticamente userID no Inserida Por
                noticia.InseridaPorID = getUserID();

                //verificar roles do utilizador
                if (User.IsInRole("Administrador") || User.IsInRole("Moderador"))
                {
                    // aprova automaticamente a noticia
                    noticia.Aprovada = true;
                    noticia.AprovadaPorID = getUserID();
                }

                // definir data
                if (noticia.DataNoticia.ToString().IsNullOrWhiteSpace())
                {
                    noticia.DataNoticia = DateTime.Now;
                }

                db.Noticias.Add(noticia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            // popular noticia com todas as categorias
            PopulateNoticiasCategorias(noticia);
            return View(noticia);
        }

        // GET: Noticias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Noticias noticias = db.Noticias.Find(id);
            Noticias noticia = db.Noticias
                .Include(n => n.ListaCategorias)
                .Where(i => i.NoticiaID == id)
                .Single();

            PopulateNoticiasCategorias(noticia);

            if (noticia == null)
            {
                return HttpNotFound();
            }

            return View(noticia);
        }

        // POST: Noticias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Noticias model, string[] selectedCategories)
        {
            var noticia = db.Noticias.Find(id);
            if (noticia == null)
            {
                return new HttpNotFoundResult();
            }

            if (ModelState.IsValid)
            {
                if (noticia.Aprovada == false && model.Aprovada == true)
                {
                    noticia.AprovadaPorID = getUserID();
                }


                // atualizar categorias
                // se nenhuma categoria for selecionada, cria uma lista de categorias
                if (selectedCategories == null)
                {
                    noticia.ListaCategorias = new List<Categorias>();
                    //return;
                }

                // Lista de categorias seleciconadas
                var newSelectedCategories = new HashSet<string>(selectedCategories);
                // Lista de categorias existentes na noticia
                var existingNoticiasCategorias = new HashSet<int>(noticia.ListaCategorias.Select(c => c.CategoriaID));

                // itera por todas as categorias
                foreach (var cat in db.Categorias)
                {
                    if (newSelectedCategories.Contains(cat.CategoriaID.ToString()))
                    {
                        // se a categoria nao estiver atribuida à noticia
                        if (!existingNoticiasCategorias.Contains(cat.CategoriaID))
                        {
                            noticia.ListaCategorias.Add(cat);
                        }
                    }
                    else
                    {
                        // se a categoria já nao estiver atribuida à noticia
                        if (existingNoticiasCategorias.Contains(cat.CategoriaID))
                        {
                            noticia.ListaCategorias.Remove(cat);
                        }
                    }
                }

                db.Entry(noticia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            PopulateNoticiasCategorias(noticia);
            return View(noticia);
        }

        // GET: Noticias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Noticias noticias = db.Noticias.Find(id);
            if (noticias == null)
            {
                return HttpNotFound();
            }
            return View(noticias);
        }

        // POST: Noticias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Noticias noticia = db.Noticias.Find(id);
            db.Noticias.Remove(noticia);
            

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // src: https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/updating-related-data-with-the-entity-framework-in-an-asp-net-mvc-application
        // popular categorias
        private void PopulateNoticiasCategorias(Noticias noticia)
        {
            var categorias = db.Categorias;
            var noticiasCategorias = new HashSet<int>(noticia.ListaCategorias.Select(c => c.CategoriaID));
            var viewModel = new List<CategoriasNoticias>();
            foreach (var categoria in categorias)
            {
                viewModel.Add(new CategoriasNoticias
                {
                    CategoriaID = categoria.CategoriaID,
                    NomeCategoria = categoria.NomeCategoria,
                    Atribuido = noticiasCategorias.Contains(categoria.CategoriaID)
                });
            }
            ViewBag.Categorias = viewModel;
        }

        // obter user ID
        private string getUserID()
        {   
            return User.Identity.GetUserId();
        }
    }
}
