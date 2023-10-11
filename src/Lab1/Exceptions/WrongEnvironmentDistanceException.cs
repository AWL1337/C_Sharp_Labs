using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

public class WrongEnvironmentDistanceException : Exception
{
    public WrongEnvironmentDistanceException()
    {
    }

    public WrongEnvironmentDistanceException(string message)
        : base(message)
    {
    }

    public WrongEnvironmentDistanceException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}