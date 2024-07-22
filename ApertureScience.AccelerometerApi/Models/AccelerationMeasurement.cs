using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ApertureScience.AccelerometerApi.Models
{
    /// <summary>
    /// Represents an acceleration measurement taken by a user.
    /// </summary>
    public class AccelerationMeasurement
    {
        /// <summary>
        /// Gets or sets the unique identifier for the acceleration measurement.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the timestamp of the measurement in Unix epoch milliseconds.
        /// </summary>
        [Required]
        [Range(0, long.MaxValue, ErrorMessage = "Timestamp must be a non-negative value.")]
        public long Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the X-axis value of the measurement.
        /// </summary>
        [Required]
        [Range(int.MinValue, int.MaxValue, ErrorMessage = "X value must be a valid 32-bit integer.")]
        public int X { get; set; }

        /// <summary>
        /// Gets or sets the Y-axis value of the measurement.
        /// </summary>
        [Required]
        [Range(int.MinValue, int.MaxValue, ErrorMessage = "Y value must be a valid 32-bit integer.")]
        public int Y { get; set; }

        /// <summary>
        /// Gets or sets the Z-axis value of the measurement.
        /// </summary>
        [Required]
        [Range(int.MinValue, int.MaxValue, ErrorMessage = "Z value must be a valid 32-bit integer.")]
        public int Z { get; set; }

        /// <summary>
        /// Gets or sets the user ID associated with the measurement.
        /// </summary>
        [Required]
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the user associated with the measurement.
        /// </summary>
        public IdentityUser User { get; set; }
    }
}
