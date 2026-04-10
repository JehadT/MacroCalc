using MacroCalc.Application.Dtos.MacroEntry.In;
using MacroCalc.Application.Dtos.MacroEntry.Out;

namespace MacroCalc.ViewModels
{
    public class MacroEntryViewModel
    {
        public MacroEntryOut ReadEntry { get; set; } = new();
        public MacroEntryIn CreateEntry { get; set; } = new();
    }
}
