namespace ApertureScience.AccelerometerApi.Models
{
    public class ValidationResult
    {
        public bool Success { get; set; }
        public string Token { get; set; }
        public IDictionary<string, string> Errors { get; set; } = new Dictionary<string, string>();
    }
}
