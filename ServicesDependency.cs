using app.api.DataContext;
using app.api.DataContext.Repository;
using app.api.Services.ClientService;
using app.api.Services.InvoiceAppService;
using app.api.Services.InvoiceDetailAppService;
using app.api.Services.ProductAppService;
using Microsoft.Extensions.DependencyInjection;

namespace app.api
{
    public static class ServicesDependency
    {
        public static void AddServiceDependency(this IServiceCollection services)
        {
            services.AddTransient(typeof(DBDataContext));

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            //AppSevices
            services.AddScoped<IClientAppService, ClientAppService>();
            services.AddScoped<IProductAppService, ProductAppService>();
            services.AddScoped<IInvoiceAppService, InvoiceAppService>();
            services.AddScoped<IInvoiceDetailAppService, InvoiceDetailAppService>();
        }
    }
}