namespace Itmo.ObjectOrientedProgramming.Lab4.Composite.Builder;

public class CompositeBuilder : ICompositeBuilder
{
    public CompositeBuilder(ICompositeNode root)
    {
        Root = root;
    }

    private ICompositeNode Root { get; }

    public void AddSubNode(ICompositeNode node)
    {
        Root.AddNode(node);
    }

    public ICompositeNode Build()
    {
        return Root;
    }
}