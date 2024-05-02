using System.ComponentModel.DataAnnotations;

namespace Notes.WebAPI.Contracts.Request
{
    public record class UserRegisterRequest(
        [Required]string login,
        [Required]string password);
}
