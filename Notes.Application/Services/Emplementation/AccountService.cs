﻿using MediatR;
using Notes.Application.CQRS.Users.Command.CreateUser;
using Notes.Application.CQRS.Users.Queries.GetUserByLogin;
using Notes.Application.Services.Abstraction;
using Notes.Application.Services.PasswordHasher;
using Notes.Domain.Models;

namespace Notes.Application.Services.Emplementation
{
    public class AccountService : IAccountService
    {
        private readonly IPasswordHash _passwordHash;
        private readonly IMediator _mediator;

        public AccountService(
            IPasswordHash passwordHash,
            IMediator mediator)
        {
            _passwordHash = passwordHash;
            _mediator = mediator;
        }

        public async Task<User> Login(string login, string password)
        {
            //найти пользователя по логину
            var user = await _mediator.Send(new GetUserByLoginRequest(login));
            //проверить пароли
            if (_passwordHash.VerifyPassword(user.PasswordHash,password))
            {
                return user;
            }
            //вернуть пользователя
        }

        public async Task RegisterAccount(CreateUserCommand command, string password)
        {
            command.PasswordHash = _passwordHash.HashPassword(password);
            await _mediator.Send(command);

        }
    }
}