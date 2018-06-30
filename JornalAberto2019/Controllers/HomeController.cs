using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JornalAberto2019.Helpers;

namespace JornalAberto2019.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
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