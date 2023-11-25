using System.Diagnostics.CodeAnalysis;
using Itmo.ObjectOrientedProgramming.Lab4.Composite.Builder;
using Itmo.ObjectOrientedProgramming.Lab4.Composite.FileNodes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Composite.Director;

public class FileDirector : IDirector
{
    public ICompositeBuilder Direct([NotNull]ICompositeBuilder builder)
    {
        var fileShow = new FileShowNode();
        var fileCopy = new FileCopyNode();
        var fileMove = new FileMoveNode();
        var fileRename = new FileRenameNode();
        var fileDelete = new FileDeleteNode();

        builder.AddSubNode(fileShow);
        builder.AddSubNode(fileCopy);
        builder.AddSubNode(fileMove);
        builder.AddSubNode(fileRename);
        builder.AddSubNode(fileDelete);

        return builder;
    }
}