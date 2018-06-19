using MediaStorage.Common;
using MediaStorage.Common.ViewModels.Menu;
using MediaStorage.Service;
using MediaStorage.Web.Attributes;
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

        [UrlConstraint]
        public ActionResult AddOrUpdate(int? id)
        {
            SetAddOrUpdateViewBags(id);

            if(id.HasValue)
            {
                var menuItem = menuItemService.GetMenuItemById(id.Value);
                if (menuItem == null)
                {
                    TempData["result"] = ServiceResult.NoRecordResult;
                    return RedirectToAction("Index");
                }
                return View(menuItem);
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

        [UrlConstraint(isNullable: false)]
        public ActionResult Remove(int id)
        {
            TempData["result"] = menuItemService.RemoveMenuItem(id);
            
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