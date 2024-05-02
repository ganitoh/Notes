using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Writers;
using Notes.Application.CQRS.Notes.Command.CreateNote;
using Notes.Application.CQRS.Notes.Command.DeleteNote;
using Notes.Application.CQRS.Notes.Queries.GetAllNotesByUser;

namespace Notes.WebAPI.Controllers
{
    [Route("note")]
    public class NoteController : Controller
    {
        private readonly IMediator _mediator;

        public NoteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateNote([FromBody] CreateNoteCommand commnad)
        {
            await _mediator.Send(commnad);
            return Ok();
        }

        [HttpGet("get-all-by-user")]
        public async Task <IActionResult> GetAllNoteByUser([FromQuery] Guid userId)
        {
            var notes = await _mediator.Send(new GetAllNotesByUserRequest(userId));
            return Ok(notes);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteNote([FromBody] DeleteNoteCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
