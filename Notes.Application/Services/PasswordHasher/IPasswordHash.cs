namespace Notes.Application.Services.PasswordHasher
{
    public interface IPasswordHash
    {
        string HashPassword(string password);
        bool VerifyPassword(string hash,string password);
    }
}
