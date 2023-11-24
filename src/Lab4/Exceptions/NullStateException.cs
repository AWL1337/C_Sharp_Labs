using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class NullStateException : Exception
{
    public NullStateException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public NullStateException()
    {
    }

    public NullStateException(string message)
        : base(message)
    {
    }
}