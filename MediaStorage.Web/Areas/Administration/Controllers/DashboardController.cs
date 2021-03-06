﻿using MediaStorage.Service;
using System.Web.Mvc;

namespace MediaStorage.Web.Areas.Administration.Controllers
{
    public class DashboardController : BaseController
    {
        public DashboardController(IMenuItemService menuItemService) 
            : base(menuItemService)
        {

        }

        public ActionResult Index()
        {
            return View();
        }
    }
}