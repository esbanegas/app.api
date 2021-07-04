using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace app.api.DataContext.Repository
{
    public class UnitOfWork : DbContext
    {
        public UnitOfWork(DbContextOptions<UnitOfWork> options) : base(options)
        {
        }
        public async Task<int> Commit()
        {
            return await base.SaveChangesAsync();
        }
        public DbSet<TEntity> CreateSet<TEntity>() where TEntity : class
        {
            return Set<TEntity>();
        }
    }
}