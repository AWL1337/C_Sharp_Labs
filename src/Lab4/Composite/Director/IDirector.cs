using Itmo.ObjectOrientedProgramming.Lab4.Composite.Builder;

namespace Itmo.ObjectOrientedProgramming.Lab4.Composite.Director;

public interface IDirector
{
    public ICompositeBuilder Direct(ICompositeBuilder builder);
}