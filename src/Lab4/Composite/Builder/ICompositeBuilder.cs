namespace Itmo.ObjectOrientedProgramming.Lab4.Composite.Builder;

public interface ICompositeBuilder
{
    public ICompositeNode Build();
    public void AddSubNode(ICompositeNode node);
}