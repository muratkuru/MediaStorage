using MediaStorage.Common;
using MediaStorage.Common.ViewModels.Menu;
using MediaStorage.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediaStorage.Web.Areas.Administration.Controllers
{
    public class MenuItemController : BaseController
    {
        IMenuItemService menuItemService;
        IMenuService menuService;
        IUserRoleService userRoleService;

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
                        TempData["result"] = new ServiceResult(false, "There is no Menu Item record for this ID.");
                        return RedirectToAction("Index");
                    }
                    return View(menuItem);
                }
                else
                {
                    TempData["result"] = new ServiceResult(false, "Invalid ID.");
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
                TempData["result"] = menuItemService.AddOrUpdateMenuItem(entity);

            return View();
        }

        public ActionResult Remove(string id)
        {
            if (int.TryParse(id, out int outID))
                TempData["result"] = menuItemService.RemoveMenuItem(outID);
            else
                TempData["result"] = new ServiceResult(false, "Invalid ID.");
            return RedirectToAction("Index");
        }

        private void SetAddOrUpdateViewBags(int? id)
        {
            ViewBag.Menus = menuService.GetAllMenusBySelectListItem(id).ToMVCSelectListItem();
            ViewBag.ParentMenuItems = menuItemService.GetMenuItemsBySelectListItem(id).ToMVCSelectListItem();
            ViewBag.UserRoles = userRoleService.GetAllUserRolesBySelectListItem(id).ToMVCSelectListItem();
        }
    }
}