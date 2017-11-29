using System.Web.Optimization;

namespace MediaStorage.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.js"));
            bundles.Add(new ScriptBundle("~/bundles/metisMenu").Include("~/Scripts/metisMenu.js"));
            bundles.Add(new ScriptBundle("~/bundles/sb-admin-2").Include("~/Scripts/sb-admin-2.js"));

            bundles.Add(new StyleBundle("~/Content/bootstrap").Include("~/Content/bootstrap.css"));
            bundles.Add(new StyleBundle("~/Content/metisMenu").Include("~/Content/metisMenu.css"));
            bundles.Add(new StyleBundle("~/Content/font-awesome").Include("~/Content/font-awesome.css"));
            bundles.Add(new StyleBundle("~/Content/sb-admin-2").Include("~/Content/sb-admin-2.css"));
        }
    }
}