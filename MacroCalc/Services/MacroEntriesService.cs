using MacroCalc.Models;
using MacroCalc.Repositories.Interfaces;
using MacroCalc.Services.Interfaces;


namespace MacroCalc.Services
{
    public class MacroEntriesService : IMacroEntriesService
    {
        private readonly IRepository<MacroEntry> _repository;

        public MacroEntriesService(IRepository<MacroEntry> repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(string userId)
        {
            MacroEntry entry = new()
            {
                Fat = 0,
                Carb = 0,
                Protein = 0,
                UserId = userId,
            };
            await _repository.AddAsync(entry);
        }

        public Task DeleteAsync(MacroEntry entry)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MacroEntry>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<MacroEntry> GetAsyncByEntryId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<MacroEntry> GetAsyncByUserId(string id)
        {
            var macroEntry = await _repository.GetAsyncByUserId(id);
            if (macroEntry == null)
            {
                throw new KeyNotFoundException($"Id: {id}, was not found.");
            }
            return macroEntry;
        }

        public async Task UpdateByAddingAsync(MacroEntry entry)
        {
            var existingEntry = await _repository.GetAsyncByEntryId(entry.Id);
            if (existingEntry == null)
            {
                throw new KeyNotFoundException($"MacroEntry with Id {entry.Id} was not found.");
            }
            existingEntry.Fat += entry.Fat;
            existingEntry.Carb += entry.Carb;
            existingEntry.Protein += entry.Protein;

            existingEntry.CalculateCalorie();

            await _repository.UpdateAsync(existingEntry);
        }

        public async Task UpdateByReplacingAsync(MacroEntry entry)
        {
            var existingEntry = await _repository.GetAsyncByEntryId(entry.Id);
            if (existingEntry == null)
            {
                throw new KeyNotFoundException($"MacroEntry with Id {entry.Id} was not found.");
            }

            existingEntry.Fat = entry.Fat;
            existingEntry.Carb = entry.Carb;
            existingEntry.Protein = entry.Protein;

            existingEntry.CalculateCalorie();

            await _repository.UpdateAsync(existingEntry);
        }
    }
}
