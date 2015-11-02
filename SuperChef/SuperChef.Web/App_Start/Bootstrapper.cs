using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using SuperChef.Web.Modules;

namespace SuperChef.Web
{
    public class Bootstrapper
    {
        public static void Run()
        {
            SetAutofacContainer();
        }

        public static void SetAutofacContainer()
        {
            //create container
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            //Register modules
            builder.RegisterModule(new InfrastructureModule());
            builder.RegisterModule(new RepositoryModule());
            builder.RegisterModule(new ServiceModule());
            builder.RegisterModule(new IdentityModule());

            //build container and set resolver
            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}