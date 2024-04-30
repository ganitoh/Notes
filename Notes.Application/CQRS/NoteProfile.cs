using AutoMapper;
using Notes.Application.CQRS.Notes.Command;
using Notes.Domain.Models;


namespace Notes.Application.CQRS
{
    public class NoteProfile : Profile
    {
        public NoteProfile()
        {
            CreateMap<CreateNoteCommand, Note>();
        }
    }
}
