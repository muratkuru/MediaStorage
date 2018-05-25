using MediaStorage.Common.ViewModels.Menu;
using MediaStorage.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediaStorage.Web.Areas.Administration.Controllers
{
    public class MenuController : BaseController
    {
        private IMenuService menuService;

        public MenuController(IMenuService menuService)
            : base(menuService)
        {
            this.menuService = menuService;
        }

        public ActionResult Index()
        {
            return View(menuService.GetAllMenus());
        }

        public ActionResult AddOrUpdate(int? id)
        {
            if(id.HasValue)
            {
                var menu = menuService.GetMenuById(id.Value);
                if (menu == null)
                    return RedirectToAction("Index");
                return View(menu);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrUpdate(MenuViewModel model)
        {
            if(ModelState.IsValid)
                TempData["result"] = menuService.AddOrUpdateMenu(model);

            return View();
        }
    }
}