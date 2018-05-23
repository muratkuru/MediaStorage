using MediaStorage.Service;
using System.Web.Mvc;

namespace MediaStorage.Web.Areas.Administration.Controllers
{
    [Authorize]
    public class DashboardController : BaseController
    {
        public DashboardController(IPageService pageService) 
            : base(pageService)
        {

        }

        public ActionResult Index()
        {
            return View();
        }
    }
}