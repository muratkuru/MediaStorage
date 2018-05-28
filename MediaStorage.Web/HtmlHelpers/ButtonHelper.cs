using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MediaStorage.Web
{
    public static class ButtonHelper
    {
         public static IHtmlString GetActiveOrPassiveButton(this HtmlHelper helper, bool isActive, string url)
        {
            string color = isActive ? "btn btn-danger" : "btn btn-success";
            string icon = isActive ? "fa fa-ban" : "fa fa-check";

            StringBuilder sb = new StringBuilder();
            sb.Append($"<a onclick=\"return confirm('Are you sure?');\" href=\"{url}\" class=\"{color}\">");
            sb.Append($"<i class=\"{icon}\"></i>");
            sb.Append("</a>");

            return new HtmlString(sb.ToString());
        }
    }
}