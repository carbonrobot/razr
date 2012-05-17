using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Razr.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Operation",
                "{controller}/{id}/{action}",
                new { controller = "Post", action = "Index" },
                new { id = @"\d+" }
            );
            
            routes.MapRoute(
                "Action", 
                "{controller}/{action}", 
                new { controller = "Home", action = "Index" }
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            
            // unity
            Bootstrapper.Initialise();

#if DEBUG
            System.Data.Entity.Database.SetInitializer<Razr.Repository.DataContext>(new Razr.Repository.RazrInitializer());
#else
            System.Data.Entity.Database.SetInitializer<Razr.Repository.DataContext>(null);
#endif 

        }
    }
}