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

            var jwtConfig = jwtConfigSection.Get<JwtConfig>();
            var key = Encoding.ASCII.GetBytes(jwtConfig.Key);

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
                    ValidIssuer = jwtConfig.Issuer,
                    ValidAudience = jwtConfig.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });

            return services;
        }
    }
}
