using JornalAberto2019.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace JornalAberto2019.Controllers
{
    public class BaseController : Controller
    {
        /**
         * Adaptado de http://afana.me/archive/2011/01/14/aspnet-mvc-internationalization.aspx/
         */
        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            string cultureName = null;

            // Tenta ler a linguagem do cookie
            HttpCookie cultureCookie = Request.Cookies["_culture"];
            if (cultureCookie != null)
            {
                cultureName = cultureCookie.Value;
            }
            else
            {
                // Linguagem vai ter o valor das headers do browser, se estas não forem null
                cultureName = Request.UserLanguages != null && Request.UserLanguages.Length > 0 ? Request.UserLanguages[0] : null;
            }

            // Valida a linguagem
            cultureName = CultureHelper.GetImplementedCulture(cultureName);

            // Define a linguagem       
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cultureName);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

            return base.BeginExecuteCore(callback, state);
        }
    }
}