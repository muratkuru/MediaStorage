using MediaStorage.Common;
using MediaStorage.Common.ViewModels.Menu;
using MediaStorage.Service;
using System.Web.Mvc;

namespace MediaStorage.Web.Areas.Administration.Controllers
{
    public class MenuController : BaseController
    {
        private IMenuService menuService;
        private IMenuItemService menuItemService;

        public MenuController(IMenuService menuService, IMenuItemService menuItemService)
            : base(menuItemService)
        {
            this.menuService = menuService;
            this.menuItemService = menuItemService;
        }

        public ActionResult Index()
        {
            return View(menuService.GetAllMenus());
        }

        public ActionResult AddOrUpdate(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                if (int.TryParse(id, out int outID))
                {
                    var menu = menuService.GetMenuById(outID);
                    if (menu == null)
                    {
                        TempData["result"] = new ServiceResult(false, "There is no menu record for this ID.");
                        return RedirectToAction("Index");
                    }
                    return View(menu);
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
        public ActionResult AddOrUpdate(MenuViewModel entity)
        {
            if (ModelState.IsValid)
            {
                if (entity.Id.HasValue)
                    TempData["result"] = menuService.UpdateMenu(entity);
                else
                    TempData["result"] = menuService.AddMenu(entity);
            }

            return View();
        }

        public ActionResult Remove(string id, bool cascadeRemove = false)
        {
            if (int.TryParse(id, out int outID))
            {
                var menuItems = menuItemService.GetMenuItemsByFilter(outID);

                if (menuItems.Count > 0 && !cascadeRemove)
                    TempData["result"] = new ServiceResult(false, 
                        "Attention! This element will deleted with child elements.", 
                        true, 
                        Url.Action("Remove", new { cascadeRemove = true })
                    );
                else
                    TempData["result"] = menuService.RemoveMenu(outID, cascadeRemove);
            }
            else
                TempData["result"] = new ServiceResult(false, "Invalid ID.");
            return RedirectToAction("Index");
        }
    }
}