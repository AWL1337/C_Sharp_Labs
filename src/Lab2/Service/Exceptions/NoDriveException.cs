using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.Exceptions;

public class NoDriveException : Exception
{
    public NoDriveException(string message)
        : base(message)
    {
    }

    public NoDriveException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public NoDriveException()
    {
    }
}