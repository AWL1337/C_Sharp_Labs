using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Service.Exceptions;

public class MarkReadReadMessageException : Exception
{
    public MarkReadReadMessageException(string message)
        : base(message)
    {
    }

    public MarkReadReadMessageException()
    {
    }

    public MarkReadReadMessageException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}