using System.Web;
using System.Web.Optimization;

namespace JornalAberto2019
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            // Frontend
            bundles.Add(new StyleBundle("~/Frontend/css").Include(
                      "~/assets/css/bootstrap.min.css",
                      "~/assets/css/owl.carousel.css",
                      "~/assets/css/owl.theme.default.css",
                      "~/assets/css/font-awesome.min.css",
                      "~/assets/css/style.css"));

            bundles.Add(new ScriptBundle("~/Frontend/js").Include(
                      "~/assets/js/jquery.min.js",
                      "~/assets/js/bootstrap.min.js",
                      "~/assets/js/owl.carousel.min.js",
                      "~/assets/js/main.js"));

            // Backend
            bundles.Add(new StyleBundle("~/Backend/css").Include(
                      "~/assets/css/bootstrap.min.css",
                      "~/assets/css/sb-admin.css",
                      "~/assets/css/font-awesome.min.css"));

            bundles.Add(new ScriptBundle("~/Backend/js").Include(
                      "~/assets/js/jquery.min.js",
                      "~/assets/js/bootstrap.min.js"));

        }
    }
}
