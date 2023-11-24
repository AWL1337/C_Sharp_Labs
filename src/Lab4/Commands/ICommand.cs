using Itmo.ObjectOrientedProgramming.Lab4.State;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public interface ICommand
{
    public void Execute();
    public void GiveState(SystemState state);
}