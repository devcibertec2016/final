using System.Web;
using System.Web.Optimization;

namespace Web_1
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/fileupload").Include(
                        "~/Scripts/jquery.ui.widget",
            "~/Scripts/jquery.iframe-transport",
            "~/Scripts/jquery.fileupload"));
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/bootstrap-datepicker.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            /* Categorias */
            bundles.Add(new ScriptBundle("~/scrp/categorias").Include(
                "~/Scripts/Modulos/jsUtil.js",
                "~/Scripts/Modulos/jsCategoria.js"));

            /* Productos */
            bundles.Add(new ScriptBundle("~/scrp/productos").Include(
               "~/Scripts/Modulos/jsUtil.js",
               "~/Scripts/Modulos/jsProductos.js"));

            /* Proveedor */
            bundles.Add(new ScriptBundle("~/scrp/proveedor").Include(
              "~/Scripts/Modulos/jsUtil.js",
              "~/Scripts/Modulos/jsProveedores.js"));

            /* Roles */
            bundles.Add(new ScriptBundle("~/scrp/roles").Include(
              "~/Scripts/Modulos/jsUtil.js",
              "~/Scripts/Modulos/jsRoles.js"));

            /* Usuarios */
            bundles.Add(new ScriptBundle("~/scrp/usuarios").Include(
              "~/Scripts/Modulos/jsUtil.js",
              "~/Scripts/Modulos/jsUsuarios.js"));
        }
    }
}
