using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public interface ICommandWithParams : ICommand
{
    public void SetParams(Collection<string> param);
}