using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Receivers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Matching;

public static class ConnectReceiverMatching
{
    public static IReceiver Match(string flag)
    {
        return flag switch
        {
            "local" => new LocalReceiver(),
            _ => throw new UnknownFlagException(),
        };
    }
}