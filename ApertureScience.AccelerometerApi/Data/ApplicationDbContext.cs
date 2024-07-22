using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ApertureScience.AccelerometerApi.Models;
using Microsoft.AspNetCore.Identity;

namespace ApertureScience.AccelerometerApi.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ActivationCode> ActivationCodes { get; set; }
        public DbSet<AccelerationMeasurement> AccelerationMeasurements { get; set; }
    }
}
