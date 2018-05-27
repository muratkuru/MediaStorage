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
        IMenuService menuService;

        public MenuItemController(IMenuService menuService) 
            : base(menuService)
        {
            this.menuService = menuService;
        }

        public ActionResult Index(int id)
        {
            return View(menuService.GetMenuItemsByMenuId(id));
        }
    }
}