using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using ApertureScience.AccelerometerApi.Models;

namespace ApertureScience.AccelerometerApi.Services
{
    /// <summary>
    /// Service for generating JWT tokens.
    /// </summary>
    public class JwtTokenService : IJwtTokenService
    {
        private readonly JwtConfig _jwtConfig;

        /// <summary>
        /// Initializes a new instance of the <see cref="JwtTokenService"/> class.
        /// </summary>
        /// <param name="configuration">The application configuration.</param>
        public JwtTokenService(IConfiguration configuration)
        {
            _jwtConfig = configuration.GetSection("Jwt").Get<JwtConfig>() ?? throw new ArgumentNullException(nameof(configuration), "JWT configuration is missing");
        }

        /// <summary>
        /// Generates a JWT token for the specified user and role.
        /// </summary>
        /// <param name="user">The user for whom the token is generated.</param>
        /// <param name="role">The role of the user.</param>
        /// <returns>A JWT token string.</returns>
        public string GenerateToken(IdentityUser user, string role)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (string.IsNullOrEmpty(role)) throw new ArgumentNullException(nameof(role));

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtConfig.Key ?? throw new InvalidOperationException("JWT key is not configured"));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id ?? throw new InvalidOperationException("User ID is null")),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email ?? throw new InvalidOperationException("User email is null")),
                    new Claim(ClaimTypes.Role, role)
                }),
                Expires = DateTime.UtcNow.AddDays(365), // Set an appropriate expiration time
                Issuer = _jwtConfig.Issuer,
                Audience = _jwtConfig.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
