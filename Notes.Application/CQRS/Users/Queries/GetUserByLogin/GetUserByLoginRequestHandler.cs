using MediatR;
using Notes.Domain.Models;
using Notes.Persistance.Services.Repositories.Abstraction;

namespace Notes.Application.CQRS.Users.Queries.GetUserByLogin
{
    public class GetUserByLoginRequestHandler
        : IRequestHandler<GetUserByLoginRequest, User>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByLoginRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(
            GetUserByLoginRequest request,
            CancellationToken cancellationToken)
        {
            return await _userRepository.GetEntityAsync(request.Login);
        }
    }
}
