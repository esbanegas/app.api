using app.api.Data.DataContext.Maps;
using app.api.DataContext.Models;
using app.api.DataContext.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace app.api.DataContext
{
    public class DBDataContext : UnitOfWork, IDBDataContext
    {
        public IConfiguration Configuration { get; }
        public DBDataContext(DbContextOptions<UnitOfWork> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetail> InvoicesDetail { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientMap());
            modelBuilder.ApplyConfiguration(new InvoiceMap());
            modelBuilder.ApplyConfiguration(new InvoiceDetailMap());
            modelBuilder.ApplyConfiguration(new ProductMap());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DBDataContext"));
            optionsBuilder.UseLazyLoadingProxies();
        }

    }
}