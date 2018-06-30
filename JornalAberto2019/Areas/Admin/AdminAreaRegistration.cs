using System.Web.Mvc;

namespace JornalAberto2019.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        // src: https://msdn.microsoft.com/pt-br/library/dn877998.aspx
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