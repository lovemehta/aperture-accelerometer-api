using System;
using System.ComponentModel.DataAnnotations;

namespace ApertureScience.AccelerometerApi.Models
{
    /// <summary>
    /// Represents an activation code used for user registration or other authentication purposes.
    /// </summary>
    public class ActivationCode
    {
        /// <summary>
        /// Gets or sets the unique identifier for the activation code.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the activation code string.
        /// </summary>
        [Required]
        public required string Code { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the activation code was created.
        /// </summary>
        [Required]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the activation code will expire.
        /// </summary>
        [Required]
        public DateTime ExpiresAt { get; set; }
    }
}
