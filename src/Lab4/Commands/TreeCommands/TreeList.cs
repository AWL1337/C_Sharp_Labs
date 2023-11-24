using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Matching;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.OutputSystem;
using Itmo.ObjectOrientedProgramming.Lab4.State;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeCommands;

public class TreeList : ICommandWithParamsFlags
{
    private const int ParamAmount = 2;
    private const int FlagAmount = 2;
    private const string DepthFlag = "-d";
    private const string ModeFlag = "-m";
    private Collection<string> _param = new Collection<string>();
    private Dictionary<string, string> _flags = new Dictionary<string, string>();

    public SystemState? State { get; private set; }

    public void Execute()
    {
        if (State is null) throw new NullStateException();
        string res = State.Receiver.ListTree(State.Head, CurrentOrDefaultDepth());
        CurrentOrDefaultMode().Show(res);
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
        if (flags.Count > FlagAmount)
        {
            throw new UnknownFlagException();
        }

        _flags = flags;
    }

    public void GiveState([NotNull]SystemState state)
    {
        State = state;
    }

    private int CurrentOrDefaultDepth()
    {
        if (!_flags.TryGetValue(DepthFlag, out string? value)) return 1;
        return int.Parse(value, new NumberFormatInfo());
    }

    private IOutputSystem CurrentOrDefaultMode()
    {
        if (!_flags.TryGetValue(ModeFlag, out string? value)) return new Console();
        return OutputSystemMatching.Match(value);
    }
}