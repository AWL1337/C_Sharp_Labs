using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.Exceptions;

public class NoCoolingSystemException : Exception
{
    public NoCoolingSystemException(string message)
        : base(message)
    {
    }

    public NoCoolingSystemException()
    {
    }

    public NoCoolingSystemException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}