

namespace Notes.Persistance.Services.Repositories.Abstraction
{
    public interface IRepository <TEntity> 
        where TEntity : class
    {
        Task<TEntity> GetEntityAsync(Guid id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task CreateEntityAsync(TEntity entity);
        Task UpdateEntityAsync(TEntity entity);
        Task DeleteEntityAsync(Guid id);
    }
}
