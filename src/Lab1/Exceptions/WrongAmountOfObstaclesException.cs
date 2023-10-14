using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

public class WrongAmountOfObstaclesException : Exception
{
    public WrongAmountOfObstaclesException()
    {
    }

    public WrongAmountOfObstaclesException(string message)
        : base(message)
    {
    }

    public WrongAmountOfObstaclesException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}