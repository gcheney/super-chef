using SuperChef.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SuperChef.Data.Repositories
{
    public abstract class RepositoryBase<TEntity>
        : IRepository<TEntity> where TEntity : class
    {
        private DbContext _dataContext;
        private DbSet<TEntity> _set;

        protected RepositoryBase(IDbContextFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
        }

        protected IDbContextFactory DatabaseFactory
        {
            get;
            private set;
        }

        protected DbContext DataContext
        {
            get { return _dataContext ?? (_dataContext = DatabaseFactory.GetContext()); }
        }

        protected DbSet<TEntity> Set
        {
            get { return _set ?? (_set = _dataContext.Set<TEntity>()); }
        }

        public virtual void Add(TEntity entity)
        {
            Set.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            Set.Attach(entity);
            _dataContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity)
        {
            Set.Remove(entity);
        }

        public virtual void Delete(Expression<Func<TEntity, bool>> where)
        {
            IEnumerable<TEntity> objects = Set.Where<TEntity>(where).AsEnumerable();
            foreach (TEntity obj in objects)
            {
                Set.Remove(obj);
            }
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return Set.ToList();
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            return Set.ToListAsync();
        }

        public virtual IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where)
        {
            return Set.Where(where).ToList();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> where)
        {
            return Set.Where(where).FirstOrDefault();
        }

        public List<TEntity> PageAll(int skip, int take)
        {
            return Set.Skip(skip).Take(take).ToList();
        }

        public Task<List<TEntity>> PageAllAsync(int skip, int take)
        {
            return Set.Skip(skip).Take(take).ToListAsync();
        }

        public TEntity FindById(object id)
        {
            return Set.Find(id);
        }

        public Task<TEntity> FindByIdAsync(object id)
        {
            return Set.FindAsync(id);
        }
    }
}
