using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

public class WrongObstacleException : Exception
{
    public WrongObstacleException()
    {
    }

    public WrongObstacleException(string message)
        : base(message)
    {
    }

    public WrongObstacleException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}