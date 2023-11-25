using System.Diagnostics.CodeAnalysis;
using Itmo.ObjectOrientedProgramming.Lab4.Composite.Builder;
using Itmo.ObjectOrientedProgramming.Lab4.Composite.TreeNodes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Composite.Director;

public class TreeDirector : IDirector
{
    public ICompositeBuilder Direct([NotNull]ICompositeBuilder builder)
    {
        var treeGo = new TreeGoNode();
        var treeList = new TreeListNode();

        builder.AddSubNode(treeGo);
        builder.AddSubNode(treeList);

        return builder;
    }
}