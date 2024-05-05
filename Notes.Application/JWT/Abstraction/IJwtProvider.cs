using Notes.Domain.Models;

namespace Notes.Application.JWT.Abstraction
{
    public interface IJwtProvider
    {
        public string GenereateToken(User user);
    }
}
