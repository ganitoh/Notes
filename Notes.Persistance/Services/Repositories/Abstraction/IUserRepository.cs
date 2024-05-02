using Notes.Domain.Models;

namespace Notes.Persistance.Services.Repositories.Abstraction
{
    public interface IUserRepository : IRepository<User> 
    {
        Task<User> GetEntityAsync(string login);
    }
}
