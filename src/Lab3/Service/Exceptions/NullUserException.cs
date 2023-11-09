using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Service.Exceptions;

public class NullUserException : Exception
{
    public NullUserException(string message)
        : base(message)
    {
    }

    public NullUserException()
    {
    }

    public NullUserException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}