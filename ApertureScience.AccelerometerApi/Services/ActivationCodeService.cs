using ApertureScience.AccelerometerApi.Data;
using ApertureScience.AccelerometerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ApertureScience.AccelerometerApi.Services
{
    public class ActivationCodeService
    {
        private readonly ApplicationDbContext _context;

        public ActivationCodeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ActivationCode> CreateActivationCodeAsync()
        {
            var code = new ActivationCode
            {
                Code = new Random().Next(100000, 999999).ToString(),
                CreatedAt = DateTime.UtcNow,
                ExpiresAt = DateTime.UtcNow.AddMinutes(60)
            };

            _context.ActivationCodes.Add(code);
            await _context.SaveChangesAsync();
            return code;
        }

    }
}
