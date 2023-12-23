namespace Domain.Exceptions;

public class UserException : Exception
{
    public UserException(string message)
        : base(message)
    {
    }

    public UserException()
    {
    }

    public UserException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}