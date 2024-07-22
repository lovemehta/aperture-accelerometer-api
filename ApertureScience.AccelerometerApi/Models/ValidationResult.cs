using System.Collections.Generic;

namespace ApertureScience.AccelerometerApi.Models
{
    /// <summary>
    /// Represents the result of a validation operation.
    /// </summary>
    public class ValidationResult
    {
        /// <summary>
        /// Gets or sets a value indicating whether the validation was successful.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the token generated during the validation, if applicable.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets a dictionary of errors encountered during the validation.
        /// </summary>
        public IDictionary<string, string> Errors { get; set; } = new Dictionary<string, string>();
    }
}
