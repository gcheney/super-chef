using Autofac;
using SuperChef.Core.Infrastructure;
using SuperChef.Data.Infrastructure;

namespace SuperChef.Web.Infrastructure.Modules
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();
            builder.RegisterType<ConnectionFactory>().As<IConnectionFactory>().InstancePerRequest();
        }
    }
}