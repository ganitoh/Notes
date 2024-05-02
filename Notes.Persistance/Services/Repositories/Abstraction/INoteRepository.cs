using Notes.Domain.Models;

namespace Notes.Persistance.Services.Repositories.Abstraction
{
    public interface INoteRepository : IRepository<Note>
    {
        Task<IEnumerable<Note>> GetAllAsync(Guid userId);
    }
}
