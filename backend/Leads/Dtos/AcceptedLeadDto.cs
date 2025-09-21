using System;

namespace LeadsAPI.Dtos
{
    public class AcceptedLeadDto
    {
        public int Id { get; set; }
        public string ContactFullName { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Suburb { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}