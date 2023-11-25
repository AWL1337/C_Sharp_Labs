using System.Diagnostics.CodeAnalysis;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Composite;

public class ConnectNode : BaseCompositeNode
{
    public override ICommand? Search([NotNull]string[] parts)
    {
        if (parts[0] != "connect") return null;

        return new Connect();
    }
}