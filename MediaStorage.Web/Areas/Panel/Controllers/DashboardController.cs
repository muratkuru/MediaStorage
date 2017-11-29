using MediaStorage.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediaStorage.Web.Areas.Panel.Controllers
{
    public class DashboardController : BaseController
    {
        public DashboardController(IPageService pageService)
            :base(pageService)
        {

        }

        public ActionResult Index()
        {
            return View();
        }
    }
}