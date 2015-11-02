
using SuperChef.Core.Infrastructure;
using System;

namespace SuperChef.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private AppDbContext _context;

        public DbFactory(IConnectionFactory connectionFactory)
        {
            Contract.Requires<ArgumentNullException>(connectionFactory != null,
                "connectionFactory cannot be null");

            //if (connectionFactory == null)
            //{
            //    throw new ArgumentNullException("connectionFactory");
            //}

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
