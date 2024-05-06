using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Writers;
using Notes.Application.CQRS.Notes.Command.CreateNote;
using Notes.Application.CQRS.Notes.Command.DeleteNote;
using Notes.Application.CQRS.Notes.Queries.GetAllNotesByUser;
using Notes.WebAPI.Contracts.Request;
using System.Security.Claims;

namespace Notes.WebAPI.Controllers
{
    [Authorize]
    [Route("note")]
    public class NoteController : Controller
    {
        private readonly IMediator _mediator;

        public NoteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateNote([FromBody] CreateNoteRequest request)
        {
            var claims = User.Claims;
            var userId  = Guid.Parse(claims.First(c => c.Type == "id").Value);
            await _mediator.Send(new CreateNoteCommand(request.Subject,request.Text,userId));
            return Ok();
        }

        [HttpGet("get-all-by-user")]
        public async Task <IActionResult> GetAllNoteByUser()
        {
            var claims = User.Claims;
            var userId = Guid.Parse(claims.First(c => c.Type == "id").Value);
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
