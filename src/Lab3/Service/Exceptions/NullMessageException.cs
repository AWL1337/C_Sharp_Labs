using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Service.Exceptions;

public class NullMessageException : Exception
{
    public NullMessageException(string message)
        : base(message)
    {
    }

    public NullMessageException()
    {
    }

    public NullMessageException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}