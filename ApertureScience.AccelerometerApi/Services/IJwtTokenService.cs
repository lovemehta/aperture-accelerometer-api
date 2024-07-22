using Microsoft.AspNetCore.Identity;

namespace ApertureScience.AccelerometerApi.Services
{
    /// <summary>
    /// Defines the functionality for generating JWT tokens.
    /// </summary>
    public interface IJwtTokenService
    {
        /// <summary>
        /// Generates a JWT token for a given user and role.
        /// </summary>
        /// <param name="user">The user for whom the token is generated.</param>
        /// <param name="role">The role of the user.</param>
        /// <returns>A JWT token string.</returns>
        string GenerateToken(IdentityUser user, string role);
    }
}
