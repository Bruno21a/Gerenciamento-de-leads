using LeadsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LeadsAPI.Data
{
    public class LeadsDbContext : DbContext
    {
        public LeadsDbContext(DbContextOptions<LeadsDbContext> options) : base(options) { }

        public DbSet<Lead> Leads { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lead>(entity =>
            {
                entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
                entity.Property(e => e.ContactFirstName).IsRequired();
                entity.Property(e => e.ContactLastName).IsRequired();
                entity.Property(e => e.ContactEmail).IsRequired();
                entity.Property(e => e.ContactPhone).IsRequired();
            });
        }
    }
}