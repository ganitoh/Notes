using MediatR;
using Notes.Persistance.Services.Repositories.Abstraction;

namespace Notes.Application.CQRS.Notes.Command.DeleteNote
{
    public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand>
    {
        private readonly INoteRepository _noteRepository;

        public DeleteNoteCommandHandler(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task Handle(
            DeleteNoteCommand request,
            CancellationToken cancellationToken)
        {
            await _noteRepository.DeleteEntityAsync(request.NoteId);
        }
    }
}
