using MediaStorage.Common.ViewModels.User;
using MediaStorage.Service;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MediaStorage.Web.Areas.Administration.Controllers
{
    public class AccountController : Controller
    {
        private IAdministratorService administratorService;

        public AccountController(IAdministratorService administratorService)
        {
            this.administratorService = administratorService;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                var result = administratorService.Login(model);

                if (result.IsSuccessful)
                {
                    FormsAuthentication.SetAuthCookie(model.Username, true);

                    var ticket = new FormsAuthenticationTicket(1, model.Username, DateTime.Now, DateTime.Now.AddDays(1), true, string.Empty);
                    string encryptedTicket = FormsAuthentication.Encrypt(ticket);

                    var httpCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    HttpContext.Response.Cookies.Add(httpCookie);

                    return RedirectToAction("Index", "Dashboard");
                }
                else
                    ModelState.AddModelError("Error", result.Message);
            }

            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}