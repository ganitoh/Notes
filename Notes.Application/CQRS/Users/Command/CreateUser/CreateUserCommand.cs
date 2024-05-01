using MediatR;

namespace Notes.Application.CQRS.Users.Command.CreateUser
{
    public class CreateUserCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public CreateUserCommand()
        {
            Id = Guid.NewGuid();
        }

        public CreateUserCommand(string login, string password)
        {
            Id = Guid.NewGuid();
            Login = login;
            Password = password;
        }
    }
}
