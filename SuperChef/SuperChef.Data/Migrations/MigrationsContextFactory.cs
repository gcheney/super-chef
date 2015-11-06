using System.Data.Entity.Infrastructure;

namespace SuperChef.Data.Migrations
{
    internal class MigrationsContextFactory : IDbContextFactory<SuperChefContext>
    {
        public SuperChefContext Create()
        {
            return new SuperChefContext("SuperChef");
        }
    }
}
