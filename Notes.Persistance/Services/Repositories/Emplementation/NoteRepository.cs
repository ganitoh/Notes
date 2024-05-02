using Microsoft.EntityFrameworkCore;
using Notes.Domain.Models;
using Notes.Persistance.Exceptions;
using Notes.Persistance.Services.Repositories.Abstraction;

namespace Notes.Persistance.Services.Repositories.Emplementation
{
    public class NoteRepository : INoteRepository
    {
        private readonly ApplicationContext _context;

        public NoteRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task CreateEntityAsync(Note entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            await _context.Notes.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEntityAsync(Guid id)
        {
            var note = await _context.Notes.FirstOrDefaultAsync(n => n.Id == id);
            if (note is null)
                throw new EntityNotFoundException("записка не найдена");

            _context.Notes.Remove(note);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Note>> GetAllAsync()
            => await _context.Notes.AsNoTracking().ToListAsync();

        public async Task<IEnumerable<Note>> GetAllAsync(Guid userId) 
            => await _context.Notes.AsNoTracking().Where(n=>n.UserId == userId).ToListAsync();

        public async Task<Note> GetEntityAsync(Guid id)
        {
            var note = await _context.Notes.AsNoTracking()
                .FirstOrDefaultAsync(n => n.Id == id);

            if (note is null)
                throw new EntityNotFoundException("записка не найдена");

            return note;
        }

        public async Task UpdateEntityAsync(Note entity)
        {
            var note = await _context.Notes.FirstOrDefaultAsync(n => n.Id == entity.Id);
            if (note is null)
                throw new EntityNotFoundException("записка не найдена");


            note.Name = entity.Name;
            note.Text = entity.Text;

            await _context.SaveChangesAsync();
        }
    }
}
