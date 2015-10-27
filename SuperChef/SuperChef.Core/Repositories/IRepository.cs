using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SuperChef.Core.Entities;

namespace SuperChef.Core.Repositories
{
    public interface IRepository<TEntity, in TKey> where  TEntity : IEntity<TKey>
    {
        List<TEntity> GetAll();
        Task<List<TEntity>> GetAllAsync();

        List<TEntity> FindAll(Expression<Func<TEntity, bool>> expression);
        Task<List<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> expression);

        List<TEntity> PageAll(int skip, int take);
        Task<List<TEntity>> PageAllAsync(int skip, int take);

        TEntity FindById(TKey id);
        Task<TEntity> FindByIdAsync(TKey id);

        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
