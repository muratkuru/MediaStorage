using MediaStorage.Common;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MediaStorage.Web
{
    public static class ResultHelper
    {
        public static IHtmlString ShowResult(this HtmlHelper helper)
        {
            StringBuilder sb = new StringBuilder();

            var tempData = helper.ViewContext.Controller.TempData["result"];
            if(tempData != null)
            {
                var result = tempData as ServiceResult;
                var alertType = result.IsSuccessful ? "alert-success" : "alert-danger";

                sb.Append($"<div class=\"alert { alertType } alert-dismissible custom-alert\" role=\"alert\">");
                sb.Append("<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>");
                sb.Append(result.Message);
                sb.Append("</div>");
            }
            return new HtmlString(sb.ToString());
        }
    }
}