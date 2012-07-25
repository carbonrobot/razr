using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Razr.Models;
using Razr.Web.Models;
using System.Web.Security;

namespace Razr.Web.Controllers
{
    public class PublicController : BaseController
    {
        [HttpGet] // GET: /
        public ActionResult Index(int page = 1, string tag = null)
        {
            var response = Service.GetRecentPosts(tag, page, 10);
            if (response.HasError)
                this.RedirectToError("There was a problem looking up posts.", response.Exception);

            var model = new HomeViewModel()
            {
                Posts = response.Result
            };
            return View(model);
        }

        [HttpGet] // GET: /archive/{slug}
        public ActionResult Slug(string slug)
        {
            var response = Service.GetPost(slug);
            var post = response.Result;
            return View("../Posts/Index", post);
        }
        
        [HttpGet] // GET: /public/about
        public ActionResult About()
        {
            return View();
        }

        [HttpGet] // GET: /public/login
        public ActionResult Login()
        {
            // check for existing users, if none exist, assume first setup
            var response = Service.Count<User>();
            if (response.HasError)
                return this.RedirectToError("Could not check for user accounts", response.Exception);

            if (response.Result < 1)
                return this.RedirectToAction("Config", "Admin");

            return View();
        }

        [HttpPost] // POST: /public/login
        public ActionResult Login(LogOnModel model, string returnUrl)
        {
            var response = Service.Login(model.UserName, model.Password);
            if (response.HasError)
                this.RedirectToError("Problem logging in", response.Exception);

            var user = response.Result;
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                return this.RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet] // GET: /public/logout
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}
