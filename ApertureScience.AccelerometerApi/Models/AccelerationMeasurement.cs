using Microsoft.AspNetCore.Identity;

namespace ApertureScience.AccelerometerApi.Models
{
    public class AccelerationMeasurement
    {
        public int Id { get; set; }
        public long Timestamp { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
    }
}
