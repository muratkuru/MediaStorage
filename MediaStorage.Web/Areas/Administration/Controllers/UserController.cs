using MediaStorage.Common;
using MediaStorage.Common.ViewModels.User;
using MediaStorage.Service;
using MediaStorage.Web.Attributes;
using System;
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

        [UrlConstraint(ConstraintType.Guid)]
        public ActionResult AddOrUpdate(Guid? id)
        {
            ViewBag.UserRoles = userRoleService.GetAllUserRolesByUserId(id).ToMVCSelectListItem();

            if(id.HasValue)
            {
                var user = userService.GetUserById(id.Value);
                if (user == null)
                {
                    TempData["result"] = ServiceResult.NoRecordResult;
                    return RedirectToAction("Index");
                }
                return View(user);
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrUpdate(UserPostViewModel entity)
        {
            ViewBag.UserRoles = userRoleService.GetAllUserRolesByUserId(entity.Id).ToMVCSelectListItem();

            if (ModelState.IsValid)
            {
                if(entity.Id.HasValue)
                    TempData["result"] = userService.UpdateUser(entity);
                else
                    TempData["result"] = userService.AddUser(entity);
            }

            return View();
        }

        [UrlConstraint(ConstraintType.Guid, isNullable: false)]
        public ActionResult Remove(Guid id)
        {
            TempData["result"] = userService.RemoveUser(id);

            return RedirectToAction("Index");
        }
    }
}