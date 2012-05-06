using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Razr.Models;
using Razr.Web.Models;

namespace Razr.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index(int page = 1)
        {
            var response = service.GetRecentPosts(page, 10);
            if (response.HasError)
                this.RedirectToError("There was a problem looking up posts.", response.Exception);

            var model = new HomeViewModel()
            {
                Posts = response.Result
            };
            return View(model);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
