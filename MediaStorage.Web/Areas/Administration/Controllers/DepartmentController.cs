using MediaStorage.Common;
using MediaStorage.Common.ViewModels.Department;
using MediaStorage.Service;
using MediaStorage.Web.Attributes;
using System.Web.Mvc;

namespace MediaStorage.Web.Areas.Administration.Controllers
{
    public class DepartmentController : BaseController
    {
        private IDepartmentService departmentService;
        private ILibraryService libraryService;

        public DepartmentController(IDepartmentService departmentService, ILibraryService libraryService, IMenuItemService menuItemService)
            : base(menuItemService)
        {
            this.departmentService = departmentService;
            this.libraryService = libraryService;
        }

        public ActionResult Index(int? id)
        {
            var departments = id.HasValue 
                ? departmentService.GetDepartmentsByLibraryId(id.Value) 
                : departmentService.GetAllDepartments();
            return View(departments);
        }

        [UrlConstraint]
        public ActionResult AddOrUpdate(int? id)
        {
            ViewBag.Libraries = libraryService.GetLibrariesAsSelectListItem(id).ToMVCSelectListItem();

            if(id.HasValue)
            {
                var department = departmentService.GetDepartmentById(id.Value);
                if (department == null)
                {
                    TempData["result"] = ServiceResult.NoRecordResult;
                    return RedirectToAction("Index");
                }
                return View(department);
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrUpdate(DepartmentViewModel entity)
        {
            ViewBag.Libraries = libraryService.GetLibrariesAsSelectListItem(entity.Id).ToMVCSelectListItem();

            if (ModelState.IsValid)
            {
                if (entity.Id.HasValue)
                    TempData["result"] = departmentService.UpdateDepartment(entity);
                else
                    TempData["result"] = departmentService.AddDepartment(entity);
            }

            return View();
        }

        // TODO: Cascade remove
        [UrlConstraint(isNullable: false)]
        public ActionResult Remove(int id, bool cascadeRemove = false)
        {
            TempData["result"] = departmentService.RemoveDepartment(id, cascadeRemove);

            return RedirectToAction("Index");
        }
    }
}