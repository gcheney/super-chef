using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SuperChef.Core.Entities;

namespace SuperChef.Core.Repositories
{
    public interface IRepository<TEntity, in TKey> where  TEntity : IEntity<TKey>
    {
        TEntity FindById(TKey id);
        TEntity Find(Expression<Func<TEntity, bool>> expression);

        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);

        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> expression);

        Task<List<TEntity>> GetAllAsync();
        Task<List<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> expression);
    }
}
