using MediaStorage.Common;
using MediaStorage.Common.ViewModels.Menu;
using MediaStorage.Service;
using MediaStorage.Web.Attributes;
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

        [UrlConstraint]
        public ActionResult AddOrUpdate(int? id)
        {
            if(id.HasValue)
            {
                var menu = menuService.GetMenuById(id.Value);
                if (menu == null)
                {
                    TempData["result"] = ServiceResult.NoRecordResult;
                    return RedirectToAction("Index");
                }
                return View(menu);
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

        [UrlConstraint(isNullable: false)]
        public ActionResult Remove(int id, bool cascadeRemove = false)
        {
            if (menuItemService.HasMenuItemsByMenuId(id) && !cascadeRemove)
                TempData["result"] = new ServiceResult
                (
                    false, 
                    "Attention! This element will delete with child elements.", 
                    true, 
                    Url.Action("Remove", new { cascadeRemove = true })
                );
            else
                TempData["result"] = menuService.RemoveMenu(id, cascadeRemove);

            return RedirectToAction("Index");
        }
    }
}