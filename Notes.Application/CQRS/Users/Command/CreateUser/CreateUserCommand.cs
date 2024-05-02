using MediatR;

namespace Notes.Application.CQRS.Users.Command.CreateUser
{
    public class CreateUserCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Login { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;

        public CreateUserCommand()
        {
            Id = Guid.NewGuid();
        }

        public CreateUserCommand(string login)
        {
            Id = Guid.NewGuid();
            Login = login;
        }

        public CreateUserCommand(string login, string password)
        {
            Id = Guid.NewGuid();
            Login = login;
            PasswordHash = password;
        }
    }
}
