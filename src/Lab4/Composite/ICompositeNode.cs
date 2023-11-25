using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Composite;

public interface ICompositeNode
{
    public ICommand? Search(string[] parts);
    public void AddNode(ICompositeNode node);
}