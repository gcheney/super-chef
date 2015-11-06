using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

using SuperChef.Core.Entities;
using SuperChef.Core.Repositories;
using SuperChef.Data.Infrastructure;

namespace SuperChef.Data.Repositories
{
    public abstract class BaseRepository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        private SuperChefContext _context;
        private IDbSet<TEntity> _dbSet;

        protected SuperChefContext Context
        {
            get { return _context ?? (_context = DbFactory.GetContext()); }
        }

        protected IDbSet<TEntity> Set
        {
            get { return _dbSet ?? (_dbSet = Context.Set<TEntity>()); }
        }

        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        public BaseRepository(IDbFactory dbFactory)
        {
            if (dbFactory == null)
            {
                throw new ArgumentNullException("dbFactory");
            }

            this.DbFactory = dbFactory;
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
                query = orderBy(query);
            }

            return query.ToList();
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
