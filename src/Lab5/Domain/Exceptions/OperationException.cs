namespace Domain.Exceptions;

public class OperationException : Exception
{
    public OperationException(string message)
        : base(message)
    {
    }

    public OperationException()
    {
    }

    public OperationException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}