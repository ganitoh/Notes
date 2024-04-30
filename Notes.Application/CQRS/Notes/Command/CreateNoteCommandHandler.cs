using AutoMapper;
using MediatR;
using Notes.Domain.Models;
using Notes.Persistance.Services.Repositories.Abstraction;

namespace Notes.Application.CQRS.Notes.Command
{
    public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand>
    {
        private readonly INoteRepository _noteRepository;
        private readonly IMapper _mapper;

        public CreateNoteCommandHandler(
            INoteRepository noteRepository,
            IMapper mapper)
        {
            _noteRepository = noteRepository;
            _mapper = mapper;
        }

        public async Task Handle(
            CreateNoteCommand request,
            CancellationToken cancellationToken)
        {
            var note = _mapper.Map<Note>(request);
            await _noteRepository.CreateEntityAsync(note);
        }
    }
}
