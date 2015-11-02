using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

using SuperChef.Core.Entities;
using SuperChef.Core.Repositories;
using SuperChef.Data.Infrastructure;
using SuperChef.Core.Infrastructure;

namespace SuperChef.Data.Repositories
{
    public abstract class Repository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        private ApplicationDbContext _context;
        private IDbSet<TEntity> _dbSet;
        private readonly IDbFactory _dbFactory;

        protected ApplicationDbContext Context
        {
            get { return _context ?? (_context = _dbFactory.GetContext()); }
        }

        protected IDbSet<TEntity> Set
        {
            get { return _dbSet ?? (_dbSet = Context.Set<TEntity>()); }
        }

        public Repository(IDbFactory dbFactory)
        {
            Contract.Requires<ArgumentNullException>(dbFactory != null, 
                "dbFactory cannot be null");

            _dbFactory = dbFactory;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return Set.ToList();
        }

        public virtual IEnumerable<TEntity> GetMany(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = Set;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual IEnumerable<TEntity> PageAll(int skip, int take)
        {
            return Set.Skip(skip).Take(take).ToList();
        }

        public virtual TEntity GetById(TKey id)
        {
            return Set.Find(id);
        }

        public virtual void Add(TEntity entity)
        {
            Set.Add(entity);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            Set.Attach(entityToUpdate);
            Context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual void Delete(TKey id)
        {
            TEntity entityToDelete = Set.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                Set.Attach(entityToDelete);
            }
            Set.Remove(entityToDelete);
        }
    }
}
