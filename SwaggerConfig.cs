using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace app.api
{
    public static class SwaggerConfig
    {
        internal static void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Simec app.api",
                    Description = "",
                });
            });
        }

        internal static void UseSwagger(IApplicationBuilder app)
        {
             app.UseSwagger(c =>
                        {
                            c.SerializeAsV2 = true;
                        });

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "App API V1");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}