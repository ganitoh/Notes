using Microsoft.AspNetCore.Mvc;
using Notes.Application.CQRS.Users.Command.CreateUser;
using Notes.Application.Services.Abstraction;
using Notes.WebAPI.Contracts.Request;

namespace Notes.WebAPI.Controllers
{
    [Route("account")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }


        public async Task<IActionResult> RegistrationAccount([FromBody] UserRegisterRequest request)
        {
            var command = new CreateUserCommand(request.login);
            await _accountService.RegisterAccount(command, request.password);
            return Ok();
        }

        
    }
}
