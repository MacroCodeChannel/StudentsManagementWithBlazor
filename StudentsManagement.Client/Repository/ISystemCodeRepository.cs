using StudentsManagement.Shared.Models;

namespace StudentsManagement.Client.Repository
{
    public interface ISystemCodeRepository
    {
        Task<SystemCode> AddAsync(SystemCode mod);

        Task<SystemCode> UpdateAsync(SystemCode mod);

        Task<SystemCode> DeleteAsync(int id);

        Task<List<SystemCode>> GetAllAsync();

        Task<SystemCode> GetByIdAsync(int id);
    }
}
