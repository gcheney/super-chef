
namespace SuperChef.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private AppDbContext _context;

        public DbFactory(IConnectionFactory connectionFactory)
        {
            var connectionString = connectionFactory.GetConnectionString();
            _context = new AppDbContext(connectionString);
        }

        public AppDbContext GetContext()
        {
            return _context;
        }

        protected override void DisposeCore()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }
}
