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
    }
}