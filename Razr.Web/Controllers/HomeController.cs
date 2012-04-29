using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Razr.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "carbonatethis";
            ViewBag.Subtitle = "simple, but effective.";
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
