using MacroCalc.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MacroCalc.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<MacroEntry> MacroEntries { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }
    }
}
