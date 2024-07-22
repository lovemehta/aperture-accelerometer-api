using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ApertureScience.AccelerometerApi.Data;
using ApertureScience.AccelerometerApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ApertureScience.AccelerometerApi.Services
{
    public class ProfileService : IProfileService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJwtTokenService _jwtTokenService;

        public ProfileService(ApplicationDbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IJwtTokenService jwtTokenService)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<ValidationResult> CreateProfileAsync(ProfileModel model)
        {
            var result = new ValidationResult();

            // Validate Activation Code
            var activationCode = await _context.ActivationCodes
                .FirstOrDefaultAsync(ac => ac.Code == model.ActivationCode && ac.ExpiresAt > DateTime.UtcNow);
            if (activationCode == null)
            {
                result.Errors.Add("ActivationCode", "Invalid or expired activation code.");
                return result;
            }

            // Validate Email
            if (!IsValidEmail(model.Email))
            {
                result.Errors.Add("Email", "Invalid email format.");
            }

            // Validate Password
            if (model.Password.Length < 8)
            {
                result.Errors.Add("Password", "Password must be at least 8 characters long.");
            }

            if (result.Errors.Count > 0)
            {
                return result;
            }

            // Ensure the TestSubject role exists
            if (!await _roleManager.RoleExistsAsync("TestSubject"))
            {
                await _roleManager.CreateAsync(new IdentityRole("TestSubject"));
            }

            // Create User
            var user = new IdentityUser { UserName = model.Email, Email = model.Email };
            var identityResult = await _userManager.CreateAsync(user, model.Password);
            if (!identityResult.Succeeded)
            {
                foreach (var error in identityResult.Errors)
                {
                    result.Errors.Add(error.Code, error.Description);
                }
                return result;
            }

            // Assign TestSubject role to the user
            await _userManager.AddToRoleAsync(user, "TestSubject");

            // Generate Token
            result.Token = _jwtTokenService.GenerateToken(user, "TestSubject");
            result.Success = true;

            return result;
        }

        private bool IsValidEmail(string email)
        {
            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            return emailRegex.IsMatch(email);
        }
    }
}
