using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.Exceptions;

public class NoRamException : Exception
{
    public NoRamException(string message)
        : base(message)
    {
    }

    public NoRamException()
    {
    }

    public NoRamException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}