using System.ComponentModel.DataAnnotations;

namespace Notes.WebAPI.Contracts.Request
{
    public record class CreateNoteRequest(
        [Required] string Subject,
        [Required]string Text);
}
