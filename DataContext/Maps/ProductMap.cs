using app.api.DataContext.BaseEntities;
using app.api.DataContext.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace app.api.Data.DataContext.Maps
{
    public class ProductMap : EntityMap<Product>
    { 
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products", "dbo");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Description).HasColumnName("Description").HasColumnType("nvarchar(128)").IsRequired();
        }
    }
}