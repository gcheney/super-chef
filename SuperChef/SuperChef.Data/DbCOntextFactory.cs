using System.Data.Entity;

namespace SuperChef.Data
{
    public class DbContextFactory : IDbContextFactory
    {
        private readonly DbContext dbContext;

        public DbContextFactory()
        {
            dbContext = new ApplicationDbContext();
        }

        public DbContext GetContext()
        {
            return dbContext;
        }
    }
}
