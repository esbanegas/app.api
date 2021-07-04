using app.api.Core;
using app.api.DataContext.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace app.api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddNewtonsoftJson();
            services.AddCors();
            services.AddControllers();
            services.AddServiceDependency();

            services.AddDbContext<UnitOfWork>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DBDataContext"));

            });

            services.AddAutoMapper(typeof(Startup).Assembly);

            SwaggerConfig.AddSwagger(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(
                options => options.SetIsOriginAllowed(x => _ = true).AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
            );

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            SwaggerConfig.UseSwagger(app);

            ProjectionsExtensionMethods.Configure(app.ApplicationServices.GetService<IMapper>());
        }
    }
}
