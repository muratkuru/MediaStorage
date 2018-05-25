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
        public MenuController(IMenuService menuService)
            : base(menuService)
        {

        }

        public ActionResult Index()
        {
            return View();
        }
    }
}