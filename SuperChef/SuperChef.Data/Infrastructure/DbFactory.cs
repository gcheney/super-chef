
using System;

namespace SuperChef.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private ApplicationDbContext _context;

        public DbFactory(IConnectionFactory connectionFactory)
        {
            if (connectionFactory == null)
            {
                throw new ArgumentNullException("connectionFactory");
            }

            var connectionString = connectionFactory.GetConnectionString();
            _context = new ApplicationDbContext(connectionString);
        }

        public ApplicationDbContext GetContext()
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
