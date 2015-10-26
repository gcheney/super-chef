using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SuperChef.Core.Repositories
{
    public interface IRepository<TEntity>
    {
        IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> filter);
        TEntity FindById(object id);

        IEnumerable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync();

        IEnumerable<TEntity> PageAll(int skip, int take);
        Task<IEnumerable<TEntity>> PageAllAsync(int skip, int take);

        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
