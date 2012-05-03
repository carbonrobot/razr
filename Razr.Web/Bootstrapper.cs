using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc3;

namespace Razr.Web
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            container.RegisterType<Razr.Services.IContext, Razr.Repository.DataContext>(new PerRequestLifetimeManager());
            container.RegisterType<Razr.Services.ILogger, Razr.Web.Util.Logger>(new PerRequestLifetimeManager());
            container.RegisterType<Razr.Services.ModelService>(new PerRequestLifetimeManager());
            
            container.RegisterControllers();

            return container;
        }
    }
}