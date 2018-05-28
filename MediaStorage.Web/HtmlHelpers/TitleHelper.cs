using System.Web.Mvc;

namespace MediaStorage.Web
{
    public static class TitleHelper
    {
        public static string GetAddOrUpdateSubTitle(this HtmlHelper helper)
        {
            return helper.ViewContext.RouteData.Values["id"] == null ? "Add" : "Update";
        }
    }
}