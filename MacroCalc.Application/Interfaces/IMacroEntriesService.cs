using MacroCalc.Application.Dtos.MacroEntry.In;
using MacroCalc.Application.Dtos.MacroEntry.Out;

namespace MacroCalc.Application.Interfaces
{
    public interface IMacroEntriesService
    {
        Task<IEnumerable<MacroEntryOut>> GetAllMacroEntries();
        Task<MacroEntryOut> GetSingleMacroEntry(string id);
        Task<MacroEntryOut> AddMacroEntry(string id);
        Task DeleteSingleMacroEntry(MacroEntryIn entry);
        Task UpdateByAddingMacroEntries(MacroEntryIn entry);
        Task UpdateByReplacingMacroEntries(MacroEntryIn entry);
    }
}
