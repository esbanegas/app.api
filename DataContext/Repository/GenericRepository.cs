
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using app.api.DataContext.BaseEntities;
using Microsoft.EntityFrameworkCore;

namespace app.api.DataContext.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : IUnitOfWork
    {
        private readonly T _unitOfWork;
        public GenericRepository(T unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IUnitOfWork UnitOfWork
        {
            get { return _unitOfWork; }
        }

        private DbSet<TEntity> GetSet<TEntity>() where TEntity : Entity
        {
            return _unitOfWork.CreateSet<TEntity>();
        }
        public void Add<TEntity>(TEntity entity) where TEntity : Entity
        {
            GetSet<TEntity>().Add(entity);
        }

        public void AddRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : Entity
        {
            GetSet<TEntity>().AddRange(entities);
        }

        public async Task<TEntity> GetSingleAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : Entity
        {
            return await GetSet<TEntity>()?.FirstOrDefaultAsync(predicate);
        }

        public async Task<List<TEntity>> GetAllAsync<TEntity>() where TEntity : Entity
        {
            return await GetSet<TEntity>().ToListAsync();
        }

        public async Task<List<TEntity>> GetFilteredAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : Entity
        {
            return await GetSet<TEntity>().Where(predicate).ToListAsync();
        }

        public void Remove<TEntity>(TEntity entity) where TEntity : Entity
        {
            if (entity == null)
            {
                return;
            }

            GetSet<TEntity>().Remove(entity);
        }

        public void RemoveRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : Entity
        {
            if (entities != null)
            {
                GetSet<TEntity>().RemoveRange(entities);
            }
        }

        public void Dispose()
        {
            if (_unitOfWork != null)
                _unitOfWork.Dispose();
        }
    }
}