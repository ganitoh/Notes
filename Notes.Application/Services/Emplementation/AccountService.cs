using MediatR;
using Notes.Application.CQRS.Users.Command.CreateUser;
using Notes.Application.CQRS.Users.Queries.GetUserByLogin;
using Notes.Application.JWT.Abstraction;
using Notes.Application.Services.Abstraction;
using Notes.Application.Services.PasswordHasher;
using Notes.Persistance.Exceptions;

namespace Notes.Application.Services.Emplementation
{
    public class AccountService : IAccountService
    {
        private readonly IPasswordHash _passwordHash;
        private readonly IMediator _mediator;
        private readonly IJwtProvider _jwtProvider;

        public AccountService(
            IPasswordHash passwordHash,
            IMediator mediator, 
            IJwtProvider jwtProvider)
        {
            _passwordHash = passwordHash;
            _mediator = mediator;
            _jwtProvider = jwtProvider;
        }

        public async Task<string> Login(string login, string password)
        {
            var user = await _mediator.Send(new GetUserByLoginRequest(login));
            if (!_passwordHash.VerifyPassword(user.PasswordHash, password))
                throw new PasswordUncorrectException("пароли не совпадают");

            var token = _jwtProvider.GenereateToken(user);
            return token;
        }

        public async Task RegisterAccount(CreateUserCommand command, string password)
        {
            command.PasswordHash = _passwordHash.HashPassword(password);
            await _mediator.Send(command);

        }
    }
}
