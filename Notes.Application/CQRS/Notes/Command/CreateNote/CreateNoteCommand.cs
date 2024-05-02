using MediatR;
using Notes.Domain.Models;

namespace Notes.Application.CQRS.Notes.Command.CreateNote
{
    public class CreateNoteCommand : IRequest
    {
        public Guid Id { get; private set; }
        public string Name { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public DateTime CreateAt { get; private set; }
        public int UserId { get; set; }

        public CreateNoteCommand()
        {
            Id = Guid.NewGuid();
            CreateAt = DateTime.Now;
        }

        public CreateNoteCommand(string name, string text, int userId)
        {
            Id = Guid.NewGuid();
            CreateAt = DateTime.Now;
            Name = name;
            Text = text;
            UserId = userId;
        }
    }
}
