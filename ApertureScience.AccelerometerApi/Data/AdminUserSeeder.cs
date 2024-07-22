using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace ApertureScience.AccelerometerApi.Configuration
{
    /// <summary>
    /// Provides methods for seeding the admin user.
    /// </summary>
    public static class AdminUserSeeder
    {
        /// <summary>
        /// Creates the admin user if it does not exist.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        public static async Task CreateAdminUser(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var scopedProvider = scope.ServiceProvider;
                var userManager = scopedProvider.GetRequiredService<UserManager<IdentityUser>>();
                var roleManager = scopedProvider.GetRequiredService<RoleManager<IdentityRole>>();

                string adminEmail = "admin@example.com";
                string adminPassword = "Admin@123456";

                if (!await roleManager.RoleExistsAsync("Administrator"))
                {
                    await roleManager.CreateAsync(new IdentityRole("Administrator"));
                }

                var adminUser = await userManager.FindByEmailAsync(adminEmail);
                if (adminUser == null)
                {
                    adminUser = new IdentityUser { UserName = adminEmail, Email = adminEmail };
                    var result = await userManager.CreateAsync(adminUser, adminPassword);
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(adminUser, "Administrator");
                    }
                }
            }
        }
    }
}
