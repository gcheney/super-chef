using System;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;

namespace SuperChef.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _context;
        private readonly IDbFactory _dbFactory;

        public UnitOfWork(IDbFactory dbFactory)
        {
            Contract.Requires<ArgumentNullException>(dbFactory != null);
            _dbFactory = dbFactory;
        }

        protected AppDbContext Context
        {
            get { return _context ?? (_context = _dbFactory.GetContext()); }
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await Context.SaveChangesAsync();
        }
    }
}
