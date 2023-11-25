using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.State;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands;

public class FileDelete : ICommandWithParams
{
    private const int ParamAmount = 3;
    private Collection<string> _param = new Collection<string>();

    public SystemState? State { get; private set; }

    public void Execute()
    {
        if (State is null) throw new NullStateException();
        State.Receiver.DeleteFile(MakePathAbsolute(_param[2], State.Head));
    }

    public void GiveState([NotNull]SystemState state)
    {
        State = state;
    }

    public void SetParams([NotNull]Collection<string> param)
    {
        if (param.Count != ParamAmount)
        {
            throw new CommandArgumentException();
        }

        _param = param;
    }

    private static string MakePathAbsolute(string path, string head)
    {
        string varstring = path;
        if (!Path.IsPathRooted(varstring))
        {
            varstring = Path.Combine(head, varstring);
        }

        return varstring;
    }
}