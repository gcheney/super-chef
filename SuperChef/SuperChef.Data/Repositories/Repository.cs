using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

using SuperChef.Core.Entities;
using SuperChef.Core.Repositories;
using SuperChef.Data.Infrastructure;

namespace SuperChef.Data.Repositories
{
    public abstract class Repository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        private AppDbContext _context;
        private DbSet<TEntity> _set;

        protected DbSet<TEntity> Set
        {
            get { return _set ?? (_set = _context.Set<TEntity>()); }
        }

        public Repository(IDbFactory dbFactory)
        {
            Contract.Requires<ArgumentNullException>(dbFactory != null);
            _context = dbFactory.GetContext();
        }

        #region Multiple Results methods
        public virtual List<TEntity> GetAll()
        {
            return Set.ToList();
        }

        public virtual Task<List<TEntity>> GetAllAsync()
        {
            return Set.ToListAsync();
        }

        public virtual List<TEntity> FindAll(Expression<Func<TEntity, bool>> expression)
        {
            return Set.Where(expression).ToList();
        }

        public virtual Task<List<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> expression)
        {
            return Set.Where(expression).ToListAsync();
        }

        public List<TEntity> PageAll(int skip, int take)
        {
            return Set.Skip(skip).Take(take).ToList();
        }

        public Task<List<TEntity>> PageAllAsync(int skip, int take)
        {
            return Set.Skip(skip).Take(take).ToListAsync();
        }
        #endregion

        #region CRUD operations
        public virtual TEntity FindById(TKey id)
        {
            return Set.Find(id);
        }

        public virtual Task<TEntity> FindByIdAsync(TKey id)
        {
            return Set.FindAsync(id);
        }

        public virtual void Insert(TEntity entity)
        {
            Set.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            var entry = _context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                Set.Attach(entity);
                entry = _context.Entry(entity);
            }
            entry.State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity)
        {
            Set.Remove(entity);
        }
        #endregion
    }
}
