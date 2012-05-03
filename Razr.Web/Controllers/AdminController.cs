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
        
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Title = "admin | carbonatethis";

            var response = service.List<Post>();
            if (response.HasError)
                this.RedirectToError("There was a problem looking up posts.", response.Exception);

            var model = new AdminViewModel()
            {
                Posts = response.Result
            };
            return View(model);
        }
        
    }
}
