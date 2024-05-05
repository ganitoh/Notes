using Notes.Application.CQRS.Users.Command.CreateUser;
using Notes.Domain.Models;

namespace Notes.Application.Services.Abstraction
{
    public interface IAccountService
    {
        Task RegisterAccount(CreateUserCommand command, string password);
        Task<string> Login(string login, string password);
    }
}
