using MediaStorage.Common;
using MediaStorage.Common.ViewModels.Department;
using MediaStorage.Service;
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

        public ActionResult AddOrUpdate(string id)
        {
            bool parameterCorrect = int.TryParse(id, out int outID);
            int? currentId = parameterCorrect ? outID : default(int?);

            ViewBag.Libraries = libraryService.GetLibrariesAsSelectListItem(currentId).ToMVCSelectListItem();

            if(!string.IsNullOrEmpty(id))
            {
                if(parameterCorrect)
                {
                    var department = departmentService.GetDepartmentById(outID);
                    if(department == null)
                    {
                        TempData["result"] = ServiceResult.NoRecordResult;
                        return RedirectToAction("Index");
                    }
                    return View(department);
                }
                else
                {
                    TempData["result"] = ServiceResult.InvalidIDResult;
                    return RedirectToAction("Index");
                }
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

        // TODO: cascade remove stocks
        public ActionResult Remove(string id, bool cascadeRemove = false)
        {
            if (int.TryParse(id, out int outID))
                TempData["result"] = departmentService.RemoveDepartment(outID, cascadeRemove);
            else
                TempData["result"] = ServiceResult.InvalidIDResult;

            return RedirectToAction("Index");
        }
    }
}