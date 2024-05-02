using MediatR;
using Notes.Domain.Models;

namespace Notes.Application.CQRS.Users.Queries.GetUserByLogin
{
    public class GetUserByLoginRequest : IRequest<User>
    {
        public string Login { get; set; } = string.Empty;
        public GetUserByLoginRequest() { }

        public GetUserByLoginRequest(string login)
        {
            Login = login;
        }
    }
}
