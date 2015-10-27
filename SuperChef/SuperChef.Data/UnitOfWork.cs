using System;
using System.Data.Entity;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using SuperChef.Core;
using SuperChef.Data.Infrastructure;

namespace SuperChef.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public UnitOfWork(IDbFactory dbFactory)
        {
            Contract.Requires<ArgumentNullException>(dbFactory != null);
            _context = dbFactory.GetContext();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
