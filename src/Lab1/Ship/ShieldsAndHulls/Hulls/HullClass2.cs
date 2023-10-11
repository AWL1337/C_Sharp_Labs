using Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ship.ShieldsAndHulls.Hulls;

public sealed class HullClass2 : BaseHull
{
    private const int HullHp = 10;
    public HullClass2()
        : base(HullHp)
    {
    }

    public override int GetDamage(BaseObstacle? obstacle)
    {
        int obstacleDamage = obstacle?.Damage ?? 0;
        return obstacleDamage * obstacle switch
        {
            Asteroid => 2,
            _ => 1,
        };
    }
}