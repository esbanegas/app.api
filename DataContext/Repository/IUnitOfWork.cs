using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;

namespace app.api.DataContext.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> Commit();
        DbSet<TEntity> CreateSet<TEntity>() where TEntity : class;
    }
}