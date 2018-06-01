using MediaStorage.Common;
using MediaStorage.Common.ViewModels.UserRole;
using MediaStorage.Service;
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

        public ActionResult AddOrUpdate(string id)
        {
            if(!string.IsNullOrEmpty(id))
            {
                if(int.TryParse(id, out int outID))
                {
                    var userRole = userRoleService.GetUserRoleById(outID);
                    if(userRole == null)
                    {
                        TempData["result"] = new ServiceResult(false, "There is no User Role record for this ID.");
                        return RedirectToAction("Index");
                    }
                    return View(userRole);
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

        public ActionResult Remove(string id)
        {
            if (int.TryParse(id, out int outID))
                TempData["result"] = userRoleService.RemoveUserRole(outID);
            else
                TempData["result"] = new ServiceResult(false, "Invalid ID.");
            return RedirectToAction("Index");
        }
    }
}