using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeadsAPI.Models
{
    public class Lead
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string ContactFirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string ContactLastName { get; set; }

        [Required]
        [MaxLength(200)]
        public string Suburb { get; set; }

        [Required]
        [MaxLength(100)]
        public string Category { get; set; }

        [Required]
        public string Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
        [EmailAddress]
        public string ContactEmail { get; set; }

        [Required]
        [Phone]
        public string ContactPhone { get; set; }

        public DateTime CreatedAt { get; set; }

        public LeadStatus Status { get; set; }

        private Lead() { }

        public static Lead Create(string firstName, string lastName, string suburb, string category,
            string description, decimal price, string email, string phone)
        {           
            var lead = new Lead
            {
                ContactFirstName = firstName,
                ContactLastName = lastName,
                Suburb = suburb,
                Category = category,
                Description = description,
                Price = price,
                ContactEmail = email,
                ContactPhone = phone,
                CreatedAt = DateTime.UtcNow,
                Status = LeadStatus.Invited
            };

            return lead;
        }
     
        public void Accept()
        {
            if (Status == LeadStatus.Accepted) return;

            Status = LeadStatus.Accepted;

            if (Price > 500m)
            {               
                Price = Math.Round(Price * 0.9m, 2, MidpointRounding.AwayFromZero);
            }
        }

        public void Decline()
        {
            if (Status == LeadStatus.Declined) return;
            Status = LeadStatus.Declined;
        }

        public void Update(string firstName, string lastName, string suburb, string category,
            string description, decimal price, string email, string phone, LeadStatus status)
        {
            ContactFirstName = firstName;
            ContactLastName = lastName;
            Suburb = suburb;
            Category = category;
            Description = description;
            Price = price;
            ContactEmail = email;
            ContactPhone = phone;
            Status = status;
        }

        public string ContactFullName() => $"{ContactFirstName} {ContactLastName}";
    }
}
