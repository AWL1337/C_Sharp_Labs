using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.Exceptions;

public class NoComputerCaseException : Exception
{
    public NoComputerCaseException(string message)
        : base(message)
    {
    }

    public NoComputerCaseException()
    {
    }

    public NoComputerCaseException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}