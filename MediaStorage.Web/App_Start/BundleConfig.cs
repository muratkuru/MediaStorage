using System.Web.Optimization;

namespace MediaStorage.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Administration script bundle
            bundles.Add(new ScriptBundle("~/Scripts/administration").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery.validate.js",
                "~/Scripts/jquery.validate.unobtrusive.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/metisMenu.js",
                "~/Scripts/sb-admin-2.js"
            ));

            // Administration style bundle
            bundles.Add(new StyleBundle("~/Content/administration").Include(
                "~/Content/bootstrap.css",
                "~/Content/metisMenu.css",
                "~/Content/font-awesome.css",
                "~/Content/sb-admin-2.css"
            ));
        }
    }
}