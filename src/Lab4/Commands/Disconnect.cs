using System.Diagnostics.CodeAnalysis;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Receivers;
using Itmo.ObjectOrientedProgramming.Lab4.State;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class Disconnect : ICommand
{
    public SystemState? State { get; private set; }

    public void Execute()
    {
        if (State is null) throw new NullStateException();

        State.Head = string.Empty;
        State.Receiver = new NoReceiver();
    }

    public void GiveState([NotNull]SystemState state)
    {
        State = state;
    }
}