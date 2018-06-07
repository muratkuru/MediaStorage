﻿using MediaStorage.Common;
using MediaStorage.Common.ViewModels.Menu;
using MediaStorage.Service;
using System.Web.Mvc;

namespace MediaStorage.Web.Areas.Administration.Controllers
{
    public class MenuController : BaseController
    {
        private IMenuService menuService;
        private IMenuItemService menuItemService;

        public MenuController(IMenuService menuService, IMenuItemService menuItemService)
            : base(menuItemService)
        {
            this.menuService = menuService;
            this.menuItemService = menuItemService;
        }

        public ActionResult Index()
        {
            return View(menuService.GetAllMenus());
        }

        public ActionResult AddOrUpdate(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                if (int.TryParse(id, out int outID))
                {
                    var menu = menuService.GetMenuById(outID);
                    if (menu == null)
                    {
                        TempData["result"] = ServiceResult.NoRecordResult;
                        return RedirectToAction("Index");
                    }
                    return View(menu);
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
        public ActionResult AddOrUpdate(MenuViewModel entity)
        {
            if (ModelState.IsValid)
            {
                if (entity.Id.HasValue)
                    TempData["result"] = menuService.UpdateMenu(entity);
                else
                    TempData["result"] = menuService.AddMenu(entity);
            }

            return View();
        }

        public ActionResult Remove(string id, bool cascadeRemove = false)
        {
            if (int.TryParse(id, out int outID))
            {
                if (menuItemService.HasMenuItemsByMenuId(outID) && !cascadeRemove)
                    TempData["result"] = new ServiceResult
                    (
                        false, 
                        "Attention! This element will delete with child elements.", 
                        true, 
                        Url.Action("Remove", new { cascadeRemove = true })
                    );
                else
                    TempData["result"] = menuService.RemoveMenu(outID, cascadeRemove);
            }
            else
                TempData["result"] = ServiceResult.InvalidIDResult;

            return RedirectToAction("Index");
        }
    }
}