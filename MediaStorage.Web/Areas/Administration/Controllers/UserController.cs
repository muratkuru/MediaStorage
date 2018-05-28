using MediaStorage.Common;
using MediaStorage.Common.ViewModels.User;
using MediaStorage.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediaStorage.Web.Areas.Administration.Controllers
{
    public class UserController : BaseController
    {
        private IUserService userService;
        private IUserRoleService userRoleService;

        public UserController(IUserService userService, IMenuItemService menuItemService, IUserRoleService userRoleService)
            : base(menuItemService)
        {
            this.userService = userService;
            this.userRoleService = userRoleService;
        }

        public ActionResult Index()
        {
            return View(userService.GetAllUsers());
        }

        public ActionResult AddOrUpdate(string id)
        {
            ViewBag.UserRoles = userRoleService.GetAllUserRolesByUserId(id).ToMVCSelectListItem();

            if(!string.IsNullOrEmpty(id))
            {
                if(Guid.TryParse(id, out Guid outID))
                {
                    var user = userService.GetUserById(outID);
                    if(user == null)
                    {
                        TempData["result"] = new ServiceResult(false, "There is no User record for this ID.");
                        return RedirectToAction("Index");
                    }
                    return View(user);
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
        public ActionResult AddOrUpdate(UserPostViewModel entity)
        {
            ViewBag.UserRoles = userRoleService.GetAllUserRolesByUserId(entity.Id).ToMVCSelectListItem();

            if (ModelState.IsValid)
                TempData["result"] = userService.AddOrUpdateUser(entity);

            return View();
        }

        public ActionResult Remove(string id)
        {
            if (Guid.TryParse(id, out Guid outID))
                TempData["result"] = userService.RemoveUser(outID);
            else
                TempData["result"] = new ServiceResult(false, "Invalid ID.");
            return RedirectToAction("Index");
        }
    }
}