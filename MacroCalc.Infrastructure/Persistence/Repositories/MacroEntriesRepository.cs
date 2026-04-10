using MacroCalc.Application.Interfaces;
using MacroCalc.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MacroCalc.Infrastructure.Persistence.Repositories
{
    public class MacroEntriesRepository : IRepository<MacroEntry>
    {
        private readonly ApplicationDbContext _context;

        public MacroEntriesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(MacroEntry entry)
        {
            _context.MacroEntries.Add(entry);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(MacroEntry entry)
        {
            _context.MacroEntries.Remove(entry);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MacroEntry>> GetAllAsync()
        {
            return await _context.MacroEntries.ToListAsync();
        }

        public async Task<MacroEntry?> GetAsyncByEntryId(int id)
        {
            return await _context.MacroEntries.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<MacroEntry?> GetAsyncByUserId(string userId)
        {
            return await _context
                .MacroEntries.Where(m => m.UserId == userId)
                .OrderByDescending(m => m.Date)
                .FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(MacroEntry entry)
        {
            _context.MacroEntries.Update(entry);
            await _context.SaveChangesAsync();
        }
    }
}
