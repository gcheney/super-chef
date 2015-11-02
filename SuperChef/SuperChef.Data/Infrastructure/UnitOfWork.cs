using System;
using SuperChef.Core.Infrastructure;


namespace SuperChef.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;
        private readonly IDbFactory _dbFactory;

        public UnitOfWork(IDbFactory dbFactory)
        {
            Contract.Requires<ArgumentNullException>(dbFactory != null,
                "dbFactory cannot be null");

            _dbFactory = dbFactory;
        }

        protected ApplicationDbContext Context
        {
            get { return _context ?? (_context = _dbFactory.GetContext()); }
        }

        public void Commit()
        {
            Context.SaveChanges();
        }
    }
}
