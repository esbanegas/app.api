using System.Security.Cryptography.X509Certificates;
using app.api.DataContext.BaseEntities;
using app.api.DataContext.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace app.api.Data.DataContext.Maps
{
    public class InvoiceDetailMap : EntityMap<InvoiceDetail>
    {
        public override void Configure(EntityTypeBuilder<InvoiceDetail> builder)
        {
            builder.ToTable("InvoicesDetail", "dbo");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.IdProduct).HasColumnName("IdProduct").HasColumnType("int").IsRequired();
            builder.Property(x => x.IdClient).HasColumnName("IdClient").HasColumnType("int").IsRequired();
            builder.Property(x => x.IdInvoice).HasColumnName("IdInvoice").HasColumnType("int").IsRequired();
            builder.Property(x => x.Quantity).HasColumnName("Quantity").HasColumnType("Decimal(18,6)").IsRequired();
            builder.Property(x => x.SubTotal).HasColumnName("SubTotal").HasColumnType("Decimal(18,6)").IsRequired();

            builder.HasOne(x => x.Client).WithMany(x => x.InvoicesDetail).HasPrincipalKey(x => x.IdClient).HasForeignKey(x => x.IdClient);
            builder.HasOne(x => x.Invoice).WithMany(x => x.InvoicesDetail).HasForeignKey(x => x.IdInvoice).OnDelete(DeleteBehavior.Restrict);
        }
    }
}