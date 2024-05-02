using System.ComponentModel.DataAnnotations;

namespace Notes.WebAPI.Contracts.Request
{
    public record class UserLoginRequest(
        [Required] string Login,
        [Required] string Password);
}
