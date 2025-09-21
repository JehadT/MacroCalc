using MacroCalc.Models;

namespace MacroCalc.Services.Interfaces
{
    public interface IMacroEntriesService
    {
        Task<IEnumerable<MacroEntry>> GetAllAsync();
        Task<MacroEntry> GetAsyncByUserId(string id);
        Task AddAsync(string id);
        Task DeleteAsync(MacroEntry entry);
        Task UpdateByAddingAsync(MacroEntry entry);
        Task UpdateByReplacingAsync(MacroEntry entry);
    }
}
