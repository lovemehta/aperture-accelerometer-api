using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ApertureScience.AccelerometerApi.Repositories
{
    /// <summary>
    /// Repository for managing test subjects in the application.
    /// </summary>
    public class TestSubjectRepository : ITestSubjectRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestSubjectRepository"/> class.
        /// </summary>
        /// <param name="userManager">The user manager.</param>
        /// <param name="roleManager">The role manager.</param>
        public TestSubjectRepository(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        /// <summary>
        /// Asynchronously retrieves all test subjects' email addresses.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of test subjects' email addresses.</returns>
        public async Task<IEnumerable<string>> GetAllTestSubjectsAsync()
        {
            var testSubjectRole = await _roleManager.FindByNameAsync("TestSubject");
            if (testSubjectRole == null)
            {
                return Enumerable.Empty<string>();
            }

            var usersInRole = await _userManager.GetUsersInRoleAsync("TestSubject");
            return usersInRole.Select(u => u.Email).Where(email => email != null)!;
        }
    }
}
