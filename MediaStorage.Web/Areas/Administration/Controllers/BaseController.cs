using MediaStorage.Service;
using System.Web.Mvc;

namespace MediaStorage.Web.Areas.Administration.Controllers
{
    public class BaseController : Controller
    {
        private IMenuItemService menuItemService;

        public BaseController(IMenuItemService menuItemService)
        {
            this.menuItemService = menuItemService;
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewBag.Menu = menuItemService.GetAdministrationMenuItems();

            base.OnActionExecuting(filterContext);
        }
    }
}