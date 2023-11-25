using System.Diagnostics.CodeAnalysis;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Composite.FileNodes;

public class FileDeleteNode : BaseCompositeNode
{
    public override ICommand? Search([NotNull]string[] parts)
    {
        if (parts[1] != "delete") return null;

        return new FileDelete();
    }
}