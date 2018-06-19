using MediaStorage.Common;
using MediaStorage.Common.ViewModels.UserRole;
using MediaStorage.Service;
using MediaStorage.Web.Attributes;
using System.Web.Mvc;

namespace MediaStorage.Web.Areas.Administration.Controllers
{
    public class UserRoleController : BaseController
    {
        private IUserRoleService userRoleService;

        public UserRoleController(IUserRoleService userRoleService, IMenuItemService menuItemService)
            : base(menuItemService)
        {
            this.userRoleService = userRoleService;
        }

        public ActionResult Index()
        {
            return View(userRoleService.GetAllUserRoles());
        }

        [UrlConstraint]
        public ActionResult AddOrUpdate(int? id)
        {
            if(id.HasValue)
            {
                var userRole = userRoleService.GetUserRoleById(id.Value);
                if (userRole == null)
                {
                    TempData["result"] = ServiceResult.NoRecordResult;
                    return RedirectToAction("Index");
                }
                return View(userRole);
            }
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrUpdate(UserRoleViewModel entity)
        {
            if (ModelState.IsValid)
            {
                if(entity.Id.HasValue)
                    TempData["result"] = userRoleService.UpdateUserRole(entity);
                else
                    TempData["result"] = userRoleService.AddUserRole(entity);
            }

            return View();
        }

        [UrlConstraint(isNullable: false)]
        public ActionResult Remove(int id)
        {
            TempData["result"] = userRoleService.RemoveUserRole(id);
            
            return RedirectToAction("Index");
        }
    }
}