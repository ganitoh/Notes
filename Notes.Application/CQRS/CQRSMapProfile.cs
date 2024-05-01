using AutoMapper;
using Notes.Application.CQRS.Notes.Command;
using Notes.Application.CQRS.Users.Command.CreateUser;
using Notes.Domain.Models;


namespace Notes.Application.CQRS
{
    public class CQRSMapProfile : Profile
    {
        public CQRSMapProfile()
        {
            CreateMap<CreateNoteCommand, Note>();
            CreateMap<CreateUserCommand, User>();
        }
    }
}
