using StudentsManagement.Shared.Models;

namespace StudentsManagement.Client.Interfaces
{
    public interface IGenericService
    {
        Task<IEnumerable<TEntity>> GetAllAsync<TEntity>() where TEntity: class;

        Task<TEntity> GetByIdAsync<TEntity>(object id) where TEntity : class;

        Task<TEntity> CreateAsync<TEntity>(TEntity entity) where TEntity : class;
        Task DeleteAsync<TEntity>(object id) where TEntity : class;
        Task DeleteAsync<TEntity>(TEntity entity) where TEntity : class;
        Task AddAsync<TEntity>(TEntity entity) where TEntity:class;

        Task UpdateAsync<TEntity>(TEntity entity) where TEntity : class;
        void Save();
        Task SaveAsync();
    }
}
