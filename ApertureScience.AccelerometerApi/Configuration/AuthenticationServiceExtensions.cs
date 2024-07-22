using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ApertureScience.AccelerometerApi.Models;

namespace ApertureScience.AccelerometerApi.Configuration
{
    /// <summary>
    /// Extension methods for configuring JWT authentication services.
    /// </summary>
    public static class AuthenticationServiceExtensions
    {
        /// <summary>
        /// Adds JWT authentication services to the specified IServiceCollection.
        /// </summary>
        /// <param name="services">The IServiceCollection to add the services to.</param>
        /// <param name="configuration">The application's IConfiguration.</param>
        /// <returns>The IServiceCollection with JWT authentication services added.</returns>
        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtConfigSection = configuration.GetSection("Jwt");
            services.Configure<JwtConfig>(jwtConfigSection);

            var jwtConfig = jwtConfigSection.Get<JwtConfig>() ?? throw new InvalidOperationException("JWT configuration is missing in appsettings.json");
            var key = Encoding.ASCII.GetBytes(jwtConfig.Key ?? throw new InvalidOperationException("JWT key is missing in the configuration"));

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtConfig.Issuer ?? throw new InvalidOperationException("JWT issuer is missing in the configuration"),
                    ValidAudience = jwtConfig.Audience ?? throw new InvalidOperationException("JWT audience is missing in the configuration"),
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });

            return services;
        }
    }
}
