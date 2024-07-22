using System.ComponentModel.DataAnnotations;

namespace ApertureScience.AccelerometerApi.Models
{
    /// <summary>
    /// Represents the login credentials for a user.
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// Gets or sets the user's email address.
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the user's password.
        /// </summary>
        [Required]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
        public string Password { get; set; }
    }
}
