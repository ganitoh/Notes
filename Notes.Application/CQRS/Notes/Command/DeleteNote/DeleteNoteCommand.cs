using MediatR;

namespace Notes.Application.CQRS.Notes.Command.DeleteNote
{
    public class DeleteNoteCommand : IRequest
    {
        public Guid NoteId { get; set; }
        public DeleteNoteCommand() { }

        public DeleteNoteCommand(Guid noteId)
        {
            NoteId = noteId;
        }
    }
}
