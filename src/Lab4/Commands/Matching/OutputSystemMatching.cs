using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.OutputSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Matching;

public static class OutputSystemMatching
{
    public static IOutputSystem Match(string flag)
    {
        return flag switch
        {
            "console" => new Console(),
            _ => throw new UnknownFlagException(),
        };
    }
}