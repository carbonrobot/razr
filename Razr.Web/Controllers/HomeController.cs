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
            ViewBag.Title = "carbonatethis";
            ViewBag.Subtitle = "simple, but effective.";

            //var plain = "Mike Rosack has written a very interesting application over at voltstats.net. His web app gathers data from users Onstar accounts and tracks the real world statistics of many Chevy Volts (close to 1000 vehicles have been registered).";
            //var markdown = new MarkdownSharp.Markdown();
            //ViewBag.Message = markdown.Transform(plain);

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
