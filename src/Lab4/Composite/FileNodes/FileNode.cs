using System.Diagnostics.CodeAnalysis;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Composite.FileNodes;

public class FileNode : BaseCompositeNode
{
    public override ICommand? Search([NotNull]string[] parts)
    {
        if (parts[0] != "file") return null;

        return base.Search(parts);
    }
}