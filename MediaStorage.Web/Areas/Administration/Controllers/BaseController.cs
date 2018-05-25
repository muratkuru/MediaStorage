using MediaStorage.Service;
using System.Web.Mvc;

namespace MediaStorage.Web.Areas.Administration.Controllers
{
    public class BaseController : Controller
    {
        private IMenuService menuService;

        public BaseController(IMenuService menuService)
        {
            this.menuService = menuService;
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewBag.Menu = menuService.GetAllMenuItems();

            base.OnActionExecuting(filterContext);
        }
    }
}