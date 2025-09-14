using MacroCalc.Data;
using MacroCalc.Models;
using MacroCalc.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MacroCalc.Repositories
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
            await _context.MacroEntries.AddAsync(entry);
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
