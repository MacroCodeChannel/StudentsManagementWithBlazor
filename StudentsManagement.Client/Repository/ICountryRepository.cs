using StudentsManagement.Shared.Models;

namespace StudentsManagement.Client.Repository
{
    public interface ICountryRepository
    {
        Task<Country> AddAsync(Country mod);

        Task<Country> UpdateAsync(Country mod);

        Task<Country> DeleteAsync(int id);

        Task<List<Country>> GetAllAsync();

        Task<Country> GetByIdAsync(int id);
    }
}
