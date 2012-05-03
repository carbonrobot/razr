using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Razr.Services;
using Microsoft.Practices.Unity;

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
