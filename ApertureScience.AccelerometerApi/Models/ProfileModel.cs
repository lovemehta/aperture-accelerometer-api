using System.ComponentModel.DataAnnotations;

namespace ApertureScience.AccelerometerApi.Models
{
    /// <summary>
    /// Represents the data required to create a user profile.
    /// </summary>
    public class ProfileModel
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

        /// <summary>
        /// Gets or sets the user's full name.
        /// </summary>
        [Required]
        [StringLength(100, ErrorMessage = "Full name cannot be longer than 100 characters.")]
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets the activation code for creating the profile.
        /// </summary>
        [Required]
        [RegularExpression(@"^\d{6}$", ErrorMessage = "Activation code must be a 6-digit number.")]
        public string ActivationCode { get; set; }
    }
}
