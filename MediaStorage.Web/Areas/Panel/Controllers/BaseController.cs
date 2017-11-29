using MediaStorage.Service;
using System.Web.Mvc;

namespace MediaStorage.Web.Areas.Panel.Controllers
{
    public class BaseController : Controller
    {
        private IPageService pageService;

        public BaseController(IPageService pageService)
        {
            this.pageService = pageService;
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewBag.Menu = pageService.GetAllPages();

            base.OnActionExecuting(filterContext);
        }
    }
}