using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Razr.Web
{

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // ex: /archive/the-post-title
            routes.MapRoute(
                "Archive",
                "archive/{slug}",
                new { Controller = "Public", Action = "Slug" }
            );
            
            // ex: /posts/1/edit
            routes.MapRoute(
                "Action",
                "{controller}/{id}/{action}",
                null,
                new { id = @"\d+" }
            );
            
            // ex: /login
            // ex: /admin/config
            routes.MapRoute(
                "Default",
                "{controller}/{action}",
                new { Controller = "Public", Action = "Index" }
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