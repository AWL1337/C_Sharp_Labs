using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Matching;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.State;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class Connect : ICommandWithParamsFlags
{
    private const int ParamAmount = 2;
    private const int FlagAmount = 1;
    private const string ModeFlag = "-m";
    private Collection<string> _param = new Collection<string>();
    private Dictionary<string, string> _flags = new Dictionary<string, string>();

    public SystemState? State { get; private set; }

    public void Execute()
    {
        if (!Path.IsPathRooted(_param[1])) throw new CommandArgumentException();
        if (State is null) throw new NullStateException();

        State.Head = _param[1];
        State.Receiver = ConnectReceiverMatching.Match(_flags[ModeFlag]);
    }

    public void SetParams([NotNull]Collection<string> param)
    {
        if (param.Count != ParamAmount)
        {
            throw new CommandArgumentException();
        }

        _param = param;
    }

    public void SetFlags([NotNull]Dictionary<string, string> flags)
    {
        if (flags.Count != FlagAmount)
        {
            throw new UnknownFlagException();
        }

        _flags = flags;
    }

    public void GiveState([NotNull]SystemState state)
    {
        State = state;
    }
}