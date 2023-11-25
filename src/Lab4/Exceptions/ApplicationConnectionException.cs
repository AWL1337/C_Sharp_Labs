using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class ApplicationConnectionException : Exception
{
    public ApplicationConnectionException(string message)
        : base(message)
    {
    }

    public ApplicationConnectionException()
    {
    }

    public ApplicationConnectionException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}