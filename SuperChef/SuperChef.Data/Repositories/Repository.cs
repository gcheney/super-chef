using SuperChef.Core.Entities;
using SuperChef.Core.Repositories;
using SuperChef.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SuperChef.Data.Repositories
{
    public abstract class Repository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        private AppDbContext _context;
        private IDbSet<TEntity> _set;

        protected IDbSet<TEntity> Set
        {
            get { return _set ?? (_set = _context.Set<TEntity>()); }
        }

        public Repository(IDbFactory factory)
        {
            _context = factory.GetContext();
        }

        #region Basic CRUD operations
        public virtual TEntity FindById(TKey id)
        {
            return Set.Find(id);
        }

        public virtual TEntity Find(Expression<Func<TEntity, bool>> expression)
        {
            return Set.Where(expression).FirstOrDefault();
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
            var entry = _context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                Set.Attach(entity);
            }
            Set.Remove(entity);
        }
        #endregion

        #region Multiple result methods
        public virtual IEnumerable<TEntity> GetAll()
        {
            return Set.ToList();
        }

        public virtual IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> expression)
        {
            return Set.Where(expression).ToList();
        }
        #endregion

        #region Async methods
        public virtual Task<List<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> expression)
        {
            return Set.Where(expression).ToListAsync();
        }

        public virtual Task<List<TEntity>> GetAllAsync()
        {
            return Set.ToListAsync();
        }
        #endregion
    }
}
