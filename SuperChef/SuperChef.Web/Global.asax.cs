using SuperChef.Web.Identity.Data;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SuperChef.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Identity Database Initilizer
            Database.SetInitializer(new IdentityDbInitializer());

            //Autofac and Automapper configuration
            Bootstrapper.Run();
        }
    }
}
