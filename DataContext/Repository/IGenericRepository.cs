using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using app.api.DataContext.BaseEntities;

namespace app.api.DataContext.Repository
{
    public interface IGenericRepository<T> : IDisposable where T : IUnitOfWork
    {
        IUnitOfWork UnitOfWork { get; }
        void Add<TEntity>(TEntity entity) where TEntity : Entity;

        void AddRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : Entity;

        Task<TEntity> GetSingleAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : Entity;

        Task<List<TEntity>> GetAllAsync<TEntity>() where TEntity : Entity;

        Task<List<TEntity>> GetFilteredAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : Entity;

        void Remove<TEntity>(TEntity entity) where TEntity : Entity;

        void RemoveRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : Entity;
    }
}