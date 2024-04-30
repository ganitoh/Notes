using MediatR;

namespace Notes.Application.CQRS.Notes.Command
{
    public class CreateNoteCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public DateTime CreateAt { get; set; }

        public CreateNoteCommand()
        {
            CreateAt = DateTime.Now;
            Id = Guid.NewGuid();
        }

        public CreateNoteCommand(string name, string text)
        {
            Name = name;
            Text = text;

            CreateAt = DateTime.Now;
            Id = Guid.NewGuid();
        }
    }
}
