namespace ApertureScience.AccelerometerApi.Models
{
    /// <summary>
    /// Represents the JWT configuration settings.
    /// </summary>
    public class JwtConfig
    {
        /// <summary>
        /// Gets or sets the JWT key.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets the JWT issuer.
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// Gets or sets the JWT audience.
        /// </summary>
        public string Audience { get; set; }
    }
}
