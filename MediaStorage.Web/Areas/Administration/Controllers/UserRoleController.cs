using MediaStorage.Common.ViewModels.UserRole;
using MediaStorage.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediaStorage.Web.Areas.Administration.Controllers
{
    public class UserRoleController : BaseController
    {
        private IUserRoleService userRoleService;

        public UserRoleController(IUserRoleService userRoleService, IMenuService menuService)
            : base(menuService)
        {
            this.userRoleService = userRoleService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddOrUpdate(int? id)
        {
            ViewBag.Title = id.HasValue ? "Update" : "Add";
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult AddOrUpdate(UserRolePostViewModel model)
        {
            if (ModelState.IsValid)
                return Json(userRoleService.AddOrUpdate(model));
            return View();
        }
    }
}