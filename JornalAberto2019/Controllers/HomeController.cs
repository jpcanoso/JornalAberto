using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using JornalAberto2019.Helpers;
using JornalAberto2019.Models;

namespace JornalAberto2019.Controllers
{
    public class HomeController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Teste()
        {
            ViewBag.Categorias = db.Categorias;
            ViewBag.Noticias = db.Noticias;
            return View();
        }

        public ActionResult Index()
        {
            ViewBag.Categorias = db.Categorias;
            ViewBag.Noticias = db.Noticias.ToList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Noticias(string searchString)
        {
            ViewBag.Categorias = db.Categorias;
            var noticias = from n in db.Noticias select n;

            if (!String.IsNullOrEmpty(searchString))
            {
                noticias = noticias.Where(s => s.Titulo.Contains(searchString));
            }

            ViewBag.Noticias = db.Noticias.ToList();

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