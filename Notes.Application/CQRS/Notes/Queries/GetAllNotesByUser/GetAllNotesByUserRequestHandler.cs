using MediatR;
using Notes.Domain.Models;
using Notes.Persistance.Services.Repositories.Abstraction;

namespace Notes.Application.CQRS.Notes.Queries.GetAllNotesByUser
{
    public class GetAllNotesByUserRequestHandler 
        : IRequestHandler<GetAllNotesByUserRequest, IEnumerable<Note>>
    {
        private readonly INoteRepository _noteRepository;

        public GetAllNotesByUserRequestHandler(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<IEnumerable<Note>> Handle(
            GetAllNotesByUserRequest request,
            CancellationToken cancellationToken)
        {
            return await _noteRepository.GetAllAsync(request.UserId);
        }
    }
}
