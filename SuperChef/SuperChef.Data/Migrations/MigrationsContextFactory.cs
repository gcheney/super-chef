using System.Data.Entity.Infrastructure;


namespace SuperChef.Data.Migrations
{
    internal class MigrationsContextFactory : IDbContextFactory<AppDbContext>
    {
        public AppDbContext Create()
        {
            return new AppDbContext("SuperChef");
        }
    }
}
