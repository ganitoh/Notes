using Microsoft.EntityFrameworkCore;
using Notes.Domain.Models;
using Notes.Persistance.Exceptions;
using Notes.Persistance.Services.Repositories.Abstraction;

namespace Notes.Persistance.Services.Repositories.Emplementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task CreateEntityAsync(User entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
            
        }

        public async Task DeleteEntityAsync(Guid id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user is null)
                throw new EntityNotFoundException("пользователь не найден");

            _context.Users.RemoveRange(user);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
            => await _context.Users.AsNoTracking().ToListAsync();
        public async Task<User> GetEntityAsync(Guid id)
        {
            var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
            if (user is null)
                throw new EntityNotFoundException("пользователь не найден");

            return user;
        }

        public async Task UpdateEntityAsync(User entity)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == entity.Id);
            if (user is null)
                throw new EntityNotFoundException("пользователь не найден");

            user.Login = entity.Login;
            await _context.SaveChangesAsync();
        }
    }
}
