namespace Domain.Exceptions;

public class AccessException : Exception
{
    public AccessException(string message)
        : base(message)
    {
    }

    public AccessException()
    {
    }

    public AccessException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}