using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ApertureScience.AccelerometerApi.Models;
using Microsoft.AspNetCore.Identity;

namespace ApertureScience.AccelerometerApi.Data
{
    /// <summary>
    /// Represents the database context for the application, including Identity and application-specific entities.
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        /// <param name="options">The options to be used by the DbContext.</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the DbSet for activation codes.
        /// </summary>
        public DbSet<ActivationCode> ActivationCodes { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for acceleration measurements.
        /// </summary>
        public DbSet<AccelerationMeasurement> AccelerationMeasurements { get; set; }
    }
}
