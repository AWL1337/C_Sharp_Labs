using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class NoCommandException : Exception
{
    public NoCommandException(string message)
        : base(message)
    {
    }

    public NoCommandException()
    {
    }

    public NoCommandException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}