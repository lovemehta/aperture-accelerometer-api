using Microsoft.AspNetCore.Identity;

namespace ApertureScience.AccelerometerApi.Services
{
    public interface IJwtTokenService
    {
        string GenerateToken(IdentityUser user, string role);
    }
}
