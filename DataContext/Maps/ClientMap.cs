using app.api.DataContext.BaseEntities;
using app.api.DataContext.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace app.api.Data.DataContext.Maps
{
    public class ClientMap : EntityMap<Client>
    {
        public override void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Clients", "dbo");
            builder.HasKey(x => x.Identifier);

            builder.Property(x => x.Identifier).HasColumnName("Identificator").HasColumnType("nvarchar(16)").IsRequired();
            builder.Property(x => x.FullName).HasColumnName("FullName").HasColumnType("nvarchar(128)").IsRequired();
            builder.Property(x => x.State).HasColumnName("State").HasColumnType("bit").IsRequired();

            builder.Property(x => x.IdClient).HasColumnName("IdClient").HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
        }
    }
}