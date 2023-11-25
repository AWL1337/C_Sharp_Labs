using System.Diagnostics.CodeAnalysis;
using Itmo.ObjectOrientedProgramming.Lab4.Composite.Builder;
using Itmo.ObjectOrientedProgramming.Lab4.Composite.FileNodes;
using Itmo.ObjectOrientedProgramming.Lab4.Composite.TreeNodes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Composite.Director;

public class ParserCompositeDirector : IDirector
{
    public ICompositeBuilder Direct([NotNull]ICompositeBuilder builder)
    {
        var connect = new ConnectNode();
        var disconnect = new DisconnectNode();
        var tree = new TreeNode();
        var file = new FileNode();

        var fileBuilder = new CompositeBuilder(file);
        var treeBuilder = new CompositeBuilder(tree);

        var fileDirector = new FileDirector();
        var treeDirector = new TreeDirector();

        builder.AddSubNode(fileDirector.Direct(fileBuilder).Build());
        builder.AddSubNode(treeDirector.Direct(treeBuilder).Build());
        builder.AddSubNode(connect);
        builder.AddSubNode(disconnect);

        return builder;
    }
}