using MediaStorage.Common.ViewModels.Menu;
using MediaStorage.Service;
using System.Web.Mvc;

namespace MediaStorage.Web.Areas.Administration.Controllers
{
    public class MenuController : BaseController
    {
        private IMenuService menuService;

        public MenuController(IMenuService menuService)
            : base(menuService)
        {
            this.menuService = menuService;
        }

        public ActionResult Index()
        {
            return View(menuService.GetAllMenus());
        }

        public ActionResult AddOrUpdate(string id)
        {
            if(!string.IsNullOrEmpty(id))
            {
                if (int.TryParse(id, out int outID))
                {
                    var menu = menuService.GetMenuById(outID);
                    if (menu == null)
                        return RedirectToAction("Index");
                    return View(menu);
                }
                else
                    return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrUpdate(MenuViewModel model)
        {
            if(ModelState.IsValid)
                TempData["result"] = menuService.AddOrUpdateMenu(model);

            return View();
        }
    }
}