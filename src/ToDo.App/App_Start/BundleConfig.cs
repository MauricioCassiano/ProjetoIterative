using System.Web;
using System.Web.Optimization;

namespace ToDo.App
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));
            bundles.Add(new ScriptBundle("~/bundles/Globaljs").Include(
                       "~/Assets/js/js-global.js",
                       "~/Assets/js/libs/jquery/plugins/jquery.unobtrusive-ajax.min.js",
                       "~/Assets/js/libs/jquery/plugins/jquery.validate-vsdoc.js",
                       "~/Assets/js/libs/jquery/plugins/jquery.validate.js",
                       "~/Assets/js/libs/jquery/plugins/jquery.validate.min.js",
                       "~/Assets/js/libs/jquery/plugins/jquery.validate.unobtrusive.js",
                       "~/Assets/js/libs/jquery/plugins/jquery.validate.unobtrusive.min.js"
                       ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Assets/css/global.css"));
        }
    }
}
