using StudentsManagement.Shared.Models;

namespace StudentsManagement.Client.Repository
{
    public interface IParentRepository
    {
        Task<Parent> AddAsync(Parent mod);

        Task<Parent> UpdateAsync(Parent mod);

        Task<Parent> DeleteAsync(int id);

        Task<List<Parent>> GetAllAsync();

        Task<Parent> GetByIdAsync(int id);
    }
}
