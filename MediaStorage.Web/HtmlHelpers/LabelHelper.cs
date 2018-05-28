using System.Web;
using System.Web.Mvc;

namespace MediaStorage.Web
{
    public static class LabelHelper
    {
        public static IHtmlString GetLabel(this HtmlHelper helper, bool isActive)
        {
            string color = isActive ? "label-success" : "label-danger";
            string message = isActive ? "Active" : "Inactive";
            return new HtmlString($"<span class=\"label {color}\">{message}</span>");
        }
    }
}