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
                if (result.IsConfirm)
                {
                    sb.Append($"<a href=\"{result.Action}\" class=\"btn btn-success btn-xs yes-no-button\">Yes</a>");
                    sb.Append($"<a href=\"#\" data-dismiss=\"alert\" class=\"btn btn-danger btn-xs yes-no-button\">No</a>");
                }
                sb.Append("</div>");
            }
            return new HtmlString(sb.ToString());
        }
    }
}