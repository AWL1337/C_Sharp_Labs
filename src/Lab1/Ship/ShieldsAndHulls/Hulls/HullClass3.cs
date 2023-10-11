using Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ship.ShieldsAndHulls.Hulls;

public sealed class HullClass3 : BaseHull
{
    private const int HullHp = 100;
    public HullClass3()
        : base(HullHp)
    {
    }

    public override int GetDamage(BaseObstacle? obstacle)
    {
        int obstacleDamage = obstacle?.Damage ?? 0;
        return obstacleDamage * obstacle switch
        {
            Asteroid => 5,
            Meteorite => 4,
            _ => 1,
        };
    }
}