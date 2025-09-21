using System.ComponentModel.DataAnnotations;

namespace LeadsAPI.Dtos
{
    public class LeadCreateDto
    {
        [Required, MaxLength(100)]
        public string ContactFirstName { get; set; }

        [Required, MaxLength(100)]
        public string ContactLastName { get; set; }

        [Required, MaxLength(200)]
        public string Suburb { get; set; }

        [Required, MaxLength(100)]
        public string Category { get; set; }

        [Required]
        public string Description { get; set; }

        [Range(0, 10000000)]
        public decimal Price { get; set; }

        [Required, EmailAddress]
        public string ContactEmail { get; set; }

        [Required, Phone]
        public string ContactPhone { get; set; }
    }
}