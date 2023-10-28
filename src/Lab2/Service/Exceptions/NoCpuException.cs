using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.Exceptions;

public class NoCpuException : Exception
{
    public NoCpuException(string message)
        : base(message)
    {
    }

    public NoCpuException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public NoCpuException()
    {
    }
}