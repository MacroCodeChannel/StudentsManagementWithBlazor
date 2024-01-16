using StudentsManagement.Shared.Models;

namespace StudentsManagement.Client.Interfaces
{
    public interface IGenericService
    {
        Task<TEntity> AddAsync<TEntity>(TEntity entity,string endpoint) where TEntity : class;

        Task<TEntity> UpdateAsync<TEntity>(TEntity entity, string endpoint) where TEntity : class;

        Task<TEntity> DeleteAsync<TEntity>(TEntity entity, string endpoint) where TEntity : class;

        Task<TEntity> DeleteAsync<TEntity>(string endpoint) where TEntity : class;

        Task<List<TEntity>> GetAllAsync<TEntity>(TEntity entity, string endpoint) where TEntity : class;

        Task<TEntity> GetByIdAsync<TEntity>(string endpoint) where TEntity : class;
    }
}
