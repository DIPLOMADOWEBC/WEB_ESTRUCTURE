using System.Web;
using System.Web.Optimization;

namespace Infiniteskills.Web
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

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/inputmask").Include(
                //~/Scripts/Inputmask/dependencyLibs/inputmask.dependencyLib.js",  //if not using jquery
                "~/Scripts/Inputmask/inputmask.js",
                "~/Scripts/Inputmask/jquery.inputmask.js",
                "~/Scripts/Inputmask/inputmask.extensions.js",
                "~/Scripts/Inputmask/inputmask.date.extensions.js",
                //and other extensions you want to include
                "~/Scripts/Inputmask/inputmask.numeric.extensions.js"));


            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/jquery.mCustomScrollbar.concat.min.js",
                      "~/Scripts/moment.min.js",
                      "~/Scripts/bootstrap-datetimepicker.min.js",
                      "~/Scripts/i18n/grid.locale-es.js",
                      "~/Scripts/jquery.jqGrid.min.js",
                      "~/Scripts/bootstrap-notify.min.js",
                      "~/Scripts/alertify.min.js",
                      "~/Scripts/jquery.backstretch.min.js",
                      "~/Scripts/jquery.uploadPreview.min.js",
                      "~/Scripts/select2.min.js",
                      "~/Scripts/pdfobject.min.js",
                      "~/Scripts/application.js",
                      "~/Scripts/respond.js"));


            bundles.Add(new ScriptBundle("~/bundles/Highcharts").Include(
              "~/Scripts/highcharts/5.0.14/highcharts.src.js",
              "~/Scripts/highcharts/5.0.14/modules/exporting.js"
               ));

            bundles.Add(new ScriptBundle("~/bundles/scriptLogin").Include(
                   "~/Scripts/bootstrap.js",
                   "~/Scripts/jquery.backstretch.min.js",
                   "~/Scripts/Login.js"
                   ));


            bundles.Add(new ScriptBundle("~/bundles/").Include(
                   "~/Scripts/bootstrap.js",
                   "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                       "~/Content/bootstrap.css",
                       "~/Content/bootstrap-datetimepicker.min.css",
                       "~/Content/ui.jqgrid-bootstrap.css",
                       "~/Content/alertifyjs/alertify.min.css",
                       "~/Content/plugins/font-awesome/css/font-awesome.css",
                       "~/Content/css/select2.min.css",
                       "~/Content/site.css",
                       "~/Content/jquery.mCustomScrollbar.min.css"));


            bundles.Add(new StyleBundle("~/Content/logincss").Include(
                    "~/Content/bootstrap.css",
                    "~/Content/login.css"));


            bundles.Add(new StyleBundle("~/Content/perfil").Include(
                 "~/Content/bootstrap.css"));

        }
    }
}
