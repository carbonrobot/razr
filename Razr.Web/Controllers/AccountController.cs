using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Razr.Web.Models;
using Razr.Models;

namespace Razr.Web.Controllers
{
    public class AccountController : BaseController
    {

        [HttpGet]
        public ActionResult Login()
        {
            // check for existing users, if none exist, assume first setup
            var response = Service.Count<User>();
            if (response.HasError)
                return this.RedirectToError("Could not check for user accounts", response.Exception);

            if (response.Result < 1)
                return this.RedirectToRoute("/admin/config");

            return View();
        }

        [HttpPost]
        public ActionResult Login(LogOnModel model, string returnUrl)
        {
            var response = Service.Login(model.UserName, model.Password);
            if (response.HasError)
                this.RedirectToError("Problem logging in", response.Exception);

            var user = response.Result;
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(model.UserName, true);
                return this.Redirect("/admin");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}
