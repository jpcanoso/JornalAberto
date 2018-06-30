using System.Web.Mvc;

namespace JornalAberto2019.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                //new { action = "Index", id = UrlParameter.Optional }
                // Controller inicial
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}