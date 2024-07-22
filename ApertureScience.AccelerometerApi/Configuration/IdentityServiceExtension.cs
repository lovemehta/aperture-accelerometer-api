using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ApertureScience.AccelerometerApi.Data;

namespace ApertureScience.AccelerometerApi.Configuration
{
    /// <summary>
    /// Extension methods for configuring identity services.
    /// </summary>
    public static class IdentityServiceExtensions
    {
        /// <summary>
        /// Adds identity services to the specified IServiceCollection.
        /// </summary>
        /// <param name="services">The IServiceCollection to add the services to.</param>
        /// <param name="configuration">The application's IConfiguration.</param>
        /// <returns>The IServiceCollection with identity services added.</returns>
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                options.EnableSensitiveDataLogging();
            });

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            return services;
        }
    }
}
