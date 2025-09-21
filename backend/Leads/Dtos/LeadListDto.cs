using System;

namespace LeadsAPI.Dtos
{
    public class LeadListDto
    {
        public int Id { get; set; }
        public string ContactFirstName { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Suburb { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}