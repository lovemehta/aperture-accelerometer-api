using System;
using System.ComponentModel.DataAnnotations;

namespace ApertureScience.AccelerometerApi.Models
{
    public class ActivationCode
    {
        public int Id { get; set; }

        [Required]
        public required string Code { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
