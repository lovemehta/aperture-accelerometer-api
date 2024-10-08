using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace ApertureScience.AccelerometerApi.Configuration
{
    /// <summary>
    /// Extension methods for configuring Swagger services.
    /// </summary>
    public static class SwaggerServiceExtensions
    {
        /// <summary>
        /// Adds Swagger services to the specified IServiceCollection.
        /// </summary>
        /// <param name="services">The IServiceCollection to add the services to.</param>
        /// <returns>The IServiceCollection with Swagger services added.</returns>
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApertureScience Accelerometer API", Version = "v1" });

                // Add JWT Authentication
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            });

            return services;
        }

        /// <summary>
        /// Uses Swagger and Swagger UI middleware in the application.
        /// </summary>
        /// <param name="app">The IApplicationBuilder to configure.</param>
        /// <returns>The IApplicationBuilder with Swagger middleware configured.</returns>
        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApertureScience Accelerometer API v1");
                c.RoutePrefix = string.Empty;
            });

            return app;
        }
    }
}
