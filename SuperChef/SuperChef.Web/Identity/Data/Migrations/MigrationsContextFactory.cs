using SuperChef.Data.Infrastructure;
using System.Data.Entity.Infrastructure;

namespace SuperChef.Web.Identity.Data.Migrations
{
    internal class MigrationsContextFactory : IDbContextFactory<IdentityContext>
    {
        public IdentityContext Create()
        {
            return new IdentityContext(new ConnectionFactory());
        }
    }
}