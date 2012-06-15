using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Razr.Models;
using Razr.Web.Models;

namespace Razr.Web.Controllers
{
    public class AdminController : BaseController
    {
        
        [HttpGet, Authorize]
        public ActionResult Index()
        {
            ViewBag.Title = "admin | carbonatethis";

            var response = Service.List<Post>();
            if (response.HasError)
                this.RedirectToError("There was a problem looking up posts.", response.Exception);

            var model = new AdminViewModel()
            {
                Posts = response.Result
            };
            return View(model);
        }

        [HttpGet]
        public ActionResult Config()
        {
            var response = Service.List<User>();
            var users = response.Result;
            if (users.Count > 0)
            {
                return this.Redirect("/login");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Config(ConfigViewModel model)
        {
            // TODO: all the usual checks
            var response = Service.Configure(model.SiteName, model.SiteTitle, model.DisplayName, model.EmailAddress, model.Password);

            // redirect to admin
            return this.Redirect("/admin");
        }
        
    }
}
