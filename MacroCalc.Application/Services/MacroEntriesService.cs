using MacroCalc.Application.Dtos.MacroEntry.In;
using MacroCalc.Application.Dtos.MacroEntry.Out;
using MacroCalc.Application.Interfaces;
using MacroCalc.Domain.Entities;


namespace MacroCalc.Application.Services
{
    public class MacroEntriesService : IMacroEntriesService
    {
        private readonly IRepository<MacroEntry> _repository;

        public MacroEntriesService(IRepository<MacroEntry> repository)
        {
            _repository = repository;
        }

        // in and out
        public async Task<MacroEntryOut> AddMacroEntry(string userId)
        {
            var macroEntryEntity = new MacroEntry()
            {
                Fat = 0,
                Carb = 0,
                Protein = 0,
                Date = DateTime.UtcNow,
                UserId = userId,
            };
            await _repository.AddAsync(macroEntryEntity);
            var macroEntryDto = new MacroEntryOut()
            {
                Id = macroEntryEntity.Id,
            };
            return macroEntryDto;
        }

        public Task DeleteSingleMacroEntry(MacroEntryIn entry)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MacroEntryOut>> GetAllMacroEntries()
        {
            throw new NotImplementedException();
        }

        // out
        public async Task<MacroEntryOut> GetSingleMacroEntry(string id)
        {
            var macroEntryEntity = await _repository.GetAsyncByUserId(id);
            if (macroEntryEntity is null)
            {
                throw new KeyNotFoundException($"Id: {id}, was not found.");
            }
            var macroEntryDto = new MacroEntryOut()
            {
                Calorie = macroEntryEntity.Calorie,
                Fat = macroEntryEntity.Fat,
                Protein = macroEntryEntity.Protein,
                Carb = macroEntryEntity.Carb,
                Id = macroEntryEntity.Id
            };
            return macroEntryDto;
        }
        // in 
        public async Task UpdateByAddingMacroEntries(MacroEntryIn macroEntryDto)
        {
            var existingEntry = await _repository.GetAsyncByEntryId(macroEntryDto.Id);
            if (existingEntry is null)
            {
                throw new KeyNotFoundException($"Macro Entry with Id {macroEntryDto.Id} was not found.");
            }
            existingEntry.Fat += macroEntryDto.Fat;
            existingEntry.Carb += macroEntryDto.Carb;
            existingEntry.Protein += macroEntryDto.Protein;

            existingEntry.CalculateCalorie();

            await _repository.UpdateAsync(existingEntry);
        }

        // in
        public async Task UpdateByReplacingMacroEntries(MacroEntryIn macroEntryDto)
        {
            var existingEntry = await _repository.GetAsyncByEntryId(macroEntryDto.Id);
            if (existingEntry is null)
            {
                throw new KeyNotFoundException($"Macro Entry with Id {macroEntryDto.Id} was not found.");
            }

            existingEntry.Fat = macroEntryDto.Fat;
            existingEntry.Carb = macroEntryDto.Carb;
            existingEntry.Protein = macroEntryDto.Protein;

            existingEntry.CalculateCalorie();

            await _repository.UpdateAsync(existingEntry);
        }
    }
}
