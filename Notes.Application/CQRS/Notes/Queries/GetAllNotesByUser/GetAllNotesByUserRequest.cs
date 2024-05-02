using MediatR;
using Notes.Domain.Models;

namespace Notes.Application.CQRS.Notes.Queries.GetAllNotesByUser
{
    public class GetAllNotesByUserRequest : IRequest<IEnumerable<Note>>
    {
        public Guid UserId { get; set; }
        public GetAllNotesByUserRequest() { }

        public GetAllNotesByUserRequest(Guid userId)
        {
            UserId = userId;
        }
    }
}
