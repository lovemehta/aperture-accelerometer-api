using ApertureScience.AccelerometerApi.Data;
using ApertureScience.AccelerometerApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ApertureScience.AccelerometerApi.Services
{
    /// <summary>
    /// Service for managing activation codes.
    /// </summary>
    public class ActivationCodeService : IActivationCodeService
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ActivationCodeService"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public ActivationCodeService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new activation code.
        /// </summary>
        /// <returns>The created <see cref="ActivationCode"/>.</returns>
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
