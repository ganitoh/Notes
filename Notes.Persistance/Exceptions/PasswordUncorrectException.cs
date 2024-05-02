
namespace Notes.Persistance.Exceptions
{
    public class PasswordUncorrectException : Exception
    {
        public PasswordUncorrectException(string message) 
            : base(message) { }
    }
}
