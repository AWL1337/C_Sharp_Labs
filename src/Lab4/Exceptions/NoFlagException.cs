using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class NoFlagException : Exception
{
    public NoFlagException(string message)
        : base(message)
    {
    }

    public NoFlagException()
    {
    }

    public NoFlagException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}