using System.ComponentModel.DataAnnotations;

namespace Notes.WebAPI.Contracts.Request
{
    public record class UserRegisterRequest(
        [Required]string Login,
        [Required]string Password);
}
