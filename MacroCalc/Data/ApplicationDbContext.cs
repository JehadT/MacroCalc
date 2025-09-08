using MacroCalc.Models;
using Microsoft.EntityFrameworkCore;

namespace MacroCalc.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<MacroEntry> MacroEntries { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder
                .Entity<MacroEntry>()
                .HasData(
                    new MacroEntry
                    {
                        Id = 1,
                        Fat = 0,
                        Carb = 0,
                        Protein = 0,
                        Date = DateTime.Now,
                        Calorie = 0,
                    }
                );
        }
    }
}
