using System;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JornalAberto2019.Helpers;
using JornalAberto2019.Models;

namespace JornalAberto2019.Controllers
{
    public class HomeController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index(string search)
        {
            ViewBag.Categorias = db.Categorias;
            var noticias = from n in db.Noticias select n;

            if (!String.IsNullOrEmpty(search))
            {
                noticias = noticias.Where(s => s.Titulo.Contains(search));
            }

            var imagem = from i in db.Imagens select i;


            ViewBag.Noticias = noticias.ToList();
            return View();
        }

        public ActionResult Sobre()
        {
            ViewBag.Categorias = db.Categorias;
            return View();
        }

        public ActionResult Categoria(int cat)
        {
            ViewBag.Categorias = db.Categorias;
            //var noticias = from n in db.Noticias where n;

            //var result = from news in db.Noticias
            //             select new
            //             {
            //                 id = news.NoticiaID,
            //                 InseridaPorID = news.InseridaPorID,
            //                 DataNoticia = news.DataNoticia,
            //                 Titulo = news.Titulo,
            //                 Descricao = news.Descricao,
            //                 Corpo = news.Corpo,
            //                 Aprovada = news.Aprovada,
            //                 AprovadaPorID = news.AprovadaPorID,
            //                 NumeroVisualizacoes = news.NumeroVisualizacoes,
            //                 NoticiasCategorias = news.ListaCategorias.Select(ca => new { id = ca.CategoriaID })
            //             };

            ViewBag.Noticias = from c in db.Categorias
                        from n in db.Noticias
                        where c.CategoriaID == cat
                        select new
                        {
                            id = n.NoticiaID,
                            InseridaPorID = n.InseridaPorID,
                            DataNoticia = n.DataNoticia,
                            Titulo = n.Titulo,
                            Descricao = n.Descricao,
                            Corpo = n.Corpo,
                            Aprovada = n.Aprovada,
                            AprovadaPorID = n.AprovadaPorID,
                            NumeroVisualizacoes = n.NumeroVisualizacoes
                        };
            //ViewBag.Noticias = teste;
            return View();
        }

        public ActionResult SetCulture(string lang)
        {
            // Validar a linguagem
            lang = CultureHelper.GetImplementedCulture(lang);

            // Guardar o cookie
            HttpCookie cookie = Request.Cookies["_culture"];
            if (cookie == null)
            {
                // criar cookie
                cookie = new HttpCookie("_culture");
                cookie.Value = lang;
            }
            else
            {
                // atualizar cookie
                cookie.Value = lang;
            }
            cookie.Expires = DateTime.Now.AddYears(1); // duração do cookie de 1 ano
            Response.Cookies.Add(cookie);
            return RedirectToAction("Index");
        }
    }
}