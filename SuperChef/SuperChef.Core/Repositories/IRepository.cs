using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SuperChef.Core.Entities;
using System.Linq;

namespace SuperChef.Core.Repositories
{
    public interface IRepository<TEntity, in TKey> where TEntity : class, IEntity<TKey>
    {
        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> GetMany(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        IEnumerable<TEntity> PageAll(int skip, int take);

        TEntity GetById(TKey id);

        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TKey id);
        void Delete(TEntity entity);
    }
}
