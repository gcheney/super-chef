using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace SuperChef.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(Expression<Func<TEntity, bool>> where);
        IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where);
        List<TEntity> PageAll(int skip, int take);
        TEntity FindById(object id);

        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Delete(Expression<Func<TEntity, bool>> where);

        Task<List<TEntity>> GetAllAsync();
        Task<List<TEntity>> PageAllAsync(int skip, int take);
        Task<TEntity> FindByIdAsync(object id);
    }
}
