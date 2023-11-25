using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Composite;

public class BaseCompositeNode : ICompositeNode
{
    private readonly Collection<ICompositeNode> _compositeNodes = new Collection<ICompositeNode>();

    public void AddNode(ICompositeNode node)
    {
        _compositeNodes.Add(node);
    }

    public virtual ICommand? Search(string[] parts)
    {
        foreach (ICompositeNode node in _compositeNodes)
        {
            ICommand? command = node.Search(parts);
            if (command is not null)
            {
                return command;
            }
        }

        return null;
    }
}