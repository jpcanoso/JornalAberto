using JornalAberto2019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JornalAberto2019.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrador,Moderador")]
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Home
        public ActionResult Index()
        {
            ViewBag.Noticias = db.Noticias.Count();
            ViewBag.Categorias = db.Categorias.Count();
            ViewBag.Users = db.Users.Count();
            return View();
        }
    }
}