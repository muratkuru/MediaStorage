using System.Web.Mvc;

namespace MediaStorage.Web
{
    public static partial class CustomHelpers
    {
        public static string GetAddOrUpdateSubTitle(this HtmlHelper helper)
        {
            return helper.ViewContext.RouteData.Values["id"] == null ? "Add" : "Update";
        }
    }
}