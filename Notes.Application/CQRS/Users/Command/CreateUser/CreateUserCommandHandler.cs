using AutoMapper;
using MediatR;
using Notes.Domain.Models;
using Notes.Persistance.Services.Repositories.Abstraction;

namespace Notes.Application.CQRS.Users.Command.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(
            IUserRepository userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task Handle(
            CreateUserCommand request,
            CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            await _userRepository.CreateEntityAsync(user);
        }
    }
}
