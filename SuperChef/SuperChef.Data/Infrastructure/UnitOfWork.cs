using System;
using SuperChef.Core.Infrastructure;

namespace SuperChef.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private SuperChefContext _context;
        private readonly IDbFactory _dbFactory;

        public UnitOfWork(IDbFactory dbFactory)
        {
            if (dbFactory == null)
            {
                throw new ArgumentNullException("dbFactory");
            }

            _dbFactory = dbFactory;
        }

        protected SuperChefContext Context
        {
            get { return _context ?? (_context = _dbFactory.GetContext()); }
        }

        public void Commit()
        {
            Context.SaveChanges();
        }
    }
}
