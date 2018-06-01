using System.Web.Mvc;

namespace MediaStorage.Web.Controllers
{
    public class ErrorsController : Controller
    {
        public ActionResult NotFound()
        {
            return View();
        }

        public ActionResult ServerError()
        {
            return View();
        }
    }
}