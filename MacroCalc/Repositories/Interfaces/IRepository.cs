
namespace MacroCalc.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetAsyncByUserId(string id);
        Task<T?> GetAsyncByEntryId(int id);
        Task AddAsync(T entry);
        Task DeleteAsync(T entry);
        Task UpdateAsync(T entry);
    }
}