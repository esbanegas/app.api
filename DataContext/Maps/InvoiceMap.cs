using app.api.DataContext.BaseEntities;
using app.api.DataContext.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace app.api.Data.DataContext.Maps
{
    public class InvoiceMap : EntityMap<Invoice>
    {
        public override void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("Invoices", "dbo");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.IndentifierClient).HasColumnName("IndentifierClient").HasColumnType("nvarchar(16)").IsRequired();
            builder.Property(x => x.Date).HasColumnName("Date").HasColumnType("DateTime").IsRequired();
            builder.Property(x => x.Total).HasColumnName("Total").HasColumnType("Decimal(18,6)").IsRequired();
        }
    }
}