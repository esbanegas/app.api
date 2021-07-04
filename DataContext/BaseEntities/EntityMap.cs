using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace app.api.DataContext.BaseEntities
{
    public class EntityMap<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : Entity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            
        }
    }
}