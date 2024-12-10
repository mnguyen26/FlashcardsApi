using Microsoft.EntityFrameworkCore;
using FlashcardsApi.Models;
using System.Text.Json;

namespace FlashcardsApi.Data
{
    public class FlashcardsDbContext : DbContext
    {
        public FlashcardsDbContext(DbContextOptions<FlashcardsDbContext> options) : base(options) { }

        public DbSet<Card> Cards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Card>(entity =>
            {
                entity.Property(e => e.Categories)
                    .HasConversion(
                        v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null), 
                        v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null) 
                    );
            });
        }
    }
}
