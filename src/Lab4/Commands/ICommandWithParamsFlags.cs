using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public interface ICommandWithParamsFlags : ICommandWithParams
{
    public void SetFlags(Dictionary<string, string> flags);
}