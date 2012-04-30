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

            var plain = "Mike Rosack has written a very interesting application over at voltstats.net. His web app gathers data from users Onstar accounts and tracks the real world statistics of many Chevy Volts (close to 1000 vehicles have been registered).";
            var markdown = new MarkdownSharp.Markdown();

            ViewBag.Message = markdown.Transform(plain);
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
