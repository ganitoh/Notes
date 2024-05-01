using FluentValidation;


namespace Notes.Application.CQRS.Users.Command.CreateUser
{
    public class CreateUserCommandValidation 
        : AbstractValidator<CreateUserCommand>
    {

        public CreateUserCommandValidation()
        {
            RuleFor(u=>u.Id).NotEmpty();
            RuleFor(u=>u.Login).NotEmpty().MaximumLength(52);
            RuleFor(u=>u.Password).NotEmpty().MaximumLength(52);
        }
    }
}
