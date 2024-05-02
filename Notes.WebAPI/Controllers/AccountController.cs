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


        [HttpPost("registration")]
        public async Task<IActionResult> RegistrationAccount([FromBody] UserRegisterRequest request)
        {
            var command = new CreateUserCommand(request.Login);
            await _accountService.RegisterAccount(command, request.Password);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
        {
            var user = await _accountService.Login(request.Login, request.Password);
            return Ok(user);
        }
    }
}
