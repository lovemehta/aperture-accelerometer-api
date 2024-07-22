using Microsoft.Extensions.DependencyInjection;
using ApertureScience.AccelerometerApi.Services;
using ApertureScience.AccelerometerApi.Repositories;

namespace ApertureScience.AccelerometerApi.Configuration
{
    /// <summary>
    /// Extension methods for configuring application services.
    /// </summary>
    public static class ApplicationServiceExtensions
    {
        /// <summary>
        /// Adds application services to the specified IServiceCollection.
        /// </summary>
        /// <param name="services">The IServiceCollection to add the services to.</param>
        /// <returns>The IServiceCollection with application services added.</returns>
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IActivationCodeService, ActivationCodeService>();
            services.AddScoped<IJwtTokenService, JwtTokenService>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<IAccelerationService, AccelerationService>();
            services.AddScoped<IBatchProcessor, BatchProcessor>();
            services.AddScoped<IAsyncConsumer, AsyncConsumer>();
            services.AddScoped<IBatchService, BatchService>();
            services.AddScoped<ITestSubjectRepository, TestSubjectRepository>();
            services.AddScoped<ITestSubjectService, TestSubjectService>();

            return services;
        }
    }
}
