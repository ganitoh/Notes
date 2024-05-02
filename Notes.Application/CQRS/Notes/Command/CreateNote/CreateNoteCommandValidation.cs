using FluentValidation;

namespace Notes.Application.CQRS.Notes.Command.CreateNote
{
    public class CreateNoteCommandValidation
        : AbstractValidator<CreateNoteCommand>
    {
        public CreateNoteCommandValidation()
        {
            RuleFor(n => n.Id).NotEmpty();
            RuleFor(n => n.UserId).NotEmpty();
            RuleFor(n => n.Text).MaximumLength(512);
            RuleFor(n => n.Name).MaximumLength(52);
        }
    }
}
