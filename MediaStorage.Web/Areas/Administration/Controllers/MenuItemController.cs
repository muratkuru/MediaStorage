using MediaStorage.Common;
using MediaStorage.Common.ViewModels.Menu;
using MediaStorage.Service;
using System.Web.Mvc;

namespace MediaStorage.Web.Areas.Administration.Controllers
{
    public class MenuItemController : BaseController
    {
        private IMenuItemService menuItemService;
        private IMenuService menuService;
        private IUserRoleService userRoleService;

        public MenuItemController(IMenuItemService menuItemService, IMenuService menuService, IUserRoleService userRoleService) 
            : base(menuItemService)
        {
            this.menuItemService = menuItemService;
            this.menuService = menuService;
            this.userRoleService = userRoleService;
        }

        public ActionResult Index(int? id)
        {
            return View(menuItemService.GetMenuItemsByFilter(id));
        }

        public ActionResult AddOrUpdate(string id)
        {
            bool parameterCorrect = int.TryParse(id, out int outID);
            int? currentId = parameterCorrect ? outID : default(int?);

            SetAddOrUpdateViewBags(currentId);

            if (!string.IsNullOrEmpty(id))
            {
                if(parameterCorrect)
                {
                    var menuItem = menuItemService.GetMenuItemById(outID);
                    if(menuItem == null)
                    {
                        TempData["result"] = ServiceResult.NoRecordResult;
                        return RedirectToAction("Index");
                    }
                    return View(menuItem);
                }
                else
                {
                    TempData["result"] = ServiceResult.InvalidIDResult;
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrUpdate(MenuItemPostViewModel entity)
        {
            SetAddOrUpdateViewBags(entity.Id);

            if (ModelState.IsValid)
            {
                if(entity.Id.HasValue)
                    TempData["result"] = menuItemService.UpdateMenuItem(entity);
                else
                    TempData["result"] = menuItemService.AddMenuItem(entity);
            }

            return View();
        }

        public ActionResult Remove(string id)
        {
            if (int.TryParse(id, out int outID))
                TempData["result"] = menuItemService.RemoveMenuItem(outID);
            else
                TempData["result"] = ServiceResult.InvalidIDResult;
            return RedirectToAction("Index");
        }

        private void SetAddOrUpdateViewBags(int? id)
        {
            ViewBag.Menus = menuService.GetAllMenusBySelectListItem(id).ToMVCSelectListItem();
            ViewBag.ParentMenuItems = menuItemService.GetMenuItemsBySelectListItem(id).ToMVCSelectListItem();
            ViewBag.UserRoles = userRoleService.GetAllUserRolesByMenuItemId(id).ToMVCSelectListItem();
        }
    }
}