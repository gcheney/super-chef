
using SuperChef.Core.Infrastructure;
using System;

namespace SuperChef.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private ApplicationDbContext _context;

        public DbFactory(IConnectionFactory connectionFactory)
        {
            Contract.Requires<ArgumentNullException>(connectionFactory != null,
                "The connectionFactory cannot be null");

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
