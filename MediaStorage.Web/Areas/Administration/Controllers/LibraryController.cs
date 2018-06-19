using MediaStorage.Common;
using MediaStorage.Common.ViewModels.Library;
using MediaStorage.Service;
using MediaStorage.Web.Attributes;
using System.Web.Mvc;

namespace MediaStorage.Web.Areas.Administration.Controllers
{
    public class LibraryController : BaseController
    {
        private ILibraryService libraryService;
        private IDepartmentService departmentService;

        public LibraryController(ILibraryService libraryService, IDepartmentService departmentService, IMenuItemService menuItemService)
            : base(menuItemService)
        {
            this.libraryService = libraryService;
            this.departmentService = departmentService;
        }

        public ActionResult Index()
        {
            return View(libraryService.GetAllLibraries());
        }

        [UrlConstraint]
        public ActionResult AddOrUpdate(int? id)
        {
            if(id.HasValue)
            {
                var library = libraryService.GetLibraryById(id.Value);
                if (library == null)
                {
                    TempData["result"] = ServiceResult.NoRecordResult;
                    return RedirectToAction("Index");
                }
                return View(library);
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrUpdate(LibraryViewModel entity)
        {
            if (ModelState.IsValid)
            {
                if (entity.Id.HasValue)
                    TempData["result"] = libraryService.UpdateLibrary(entity);
                else
                    TempData["result"] = libraryService.AddLibrary(entity);
            }

            return View();
        }

        [UrlConstraint(isNullable: false)]
        public ActionResult Remove(int id, bool cascadeRemove = false)
        {
            if(departmentService.HasDepartmentsByLibraryId(id) && !cascadeRemove)
            {
                TempData["result"] = new ServiceResult
                (
                    false,
                    "Attention! This element will delete with child elements.",
                    true,
                    Url.Action("Remove", new { cascadeRemove = true })
                );
            }
            else
                TempData["result"] = libraryService.RemoveLibrary(id, cascadeRemove);

            return RedirectToAction("Index");
        }
    }
}