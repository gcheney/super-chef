
using System;

namespace SuperChef.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private SuperChefContext _context;

        public DbFactory(IConnectionFactory connectionFactory)
        {
            if (connectionFactory == null)
            {
                throw new ArgumentNullException("connectionFactory");
            }

            var connectionString = connectionFactory.GetConnectionString();
            _context = new SuperChefContext(connectionString);
        }

        public SuperChefContext GetContext()
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
