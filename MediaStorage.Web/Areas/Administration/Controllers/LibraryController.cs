using MediaStorage.Common;
using MediaStorage.Common.ViewModels.Library;
using MediaStorage.Service;
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

        public ActionResult AddOrUpdate(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                if (int.TryParse(id, out int outID))
                {
                    var library = libraryService.GetLibraryById(outID);
                    if (library == null)
                    {
                        TempData["result"] = new ServiceResult(false, "There is no library record for this ID.");
                        return RedirectToAction("Index");
                    }
                    return View(library);
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

        public ActionResult Remove(string id, bool cascadeRemove = false)
        {
            if (int.TryParse(id, out int outID))
            {
                if(departmentService.HasDepartmentsByLibraryId(outID) && !cascadeRemove)
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
                    TempData["result"] = libraryService.RemoveLibrary(outID, cascadeRemove);
            }
            else
                TempData["result"] = new ServiceResult(false, "Invalid ID.");

            return RedirectToAction("Index");
        }
    }
}