using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Razr.Services;
using Microsoft.Practices.Unity;
using Razr.Models;

namespace Razr.Web.Controllers
{
    public class BaseController : Controller
    {
        protected ModelService service
        {
            get
            {
                return DependencyResolver.Current.GetService<Razr.Services.ModelService>();
            }
        }

        public BaseController()
        {
            var response = service.List<Blog>();
<<<<<<< HEAD
            if (response.Result.Count > 0)
            {
                var blog = response.Result[0];
                ViewBag.SiteName = blog.SiteName;
                ViewBag.SiteTitle = blog.Title;
            }
            else
            {
                // TODO: can we redirect from here?
=======
            if (response.HasError)
                throw new Exception("No idea what happened");

            var blogs = response.Result;
            if (blogs.Count > 0)
            {
                ViewBag.SiteName = blogs[0].SiteName;
                ViewBag.SiteTitle = blogs[0].Title;
            }
            else
            {
                this.Redirect("/admin/config");
>>>>>>> 01b6cfec74bd04bda87ac4079359573b7fdf72b2
            }
        }

        /// <summary>
        /// Redirect the user to a general error page
        /// </summary>
        /// <param name="friendlyMessage">A friendly error message to present to the user</param>
        /// <param name="exception">An exception to present to developers</param>
        /// <returns></returns>
        public ActionResult RedirectToError(string friendlyMessage, Exception exception)
        {
            ViewBag.Error = friendlyMessage;
            ViewBag.Exception = exception.ToString();

            return this.Redirect("/error");
        }


    }
}
