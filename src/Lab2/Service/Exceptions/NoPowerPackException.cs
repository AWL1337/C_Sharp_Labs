using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.Exceptions;

public class NoPowerPackException : Exception
{
    public NoPowerPackException(string message)
        : base(message)
    {
    }

    public NoPowerPackException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public NoPowerPackException()
    {
    }
}