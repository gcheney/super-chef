using System.Data.Entity.Infrastructure;

namespace SuperChef.Data.Migrations
{
    internal class MigrationsContextFactory : IDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext Create()
        {
            return new ApplicationDbContext("SuperChef");
        }
    }
}
