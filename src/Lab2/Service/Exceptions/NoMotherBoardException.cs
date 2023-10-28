using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.Exceptions;

public class NoMotherBoardException : Exception
{
    public NoMotherBoardException(string message)
        : base(message)
    {
    }

    public NoMotherBoardException()
    {
    }

    public NoMotherBoardException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}