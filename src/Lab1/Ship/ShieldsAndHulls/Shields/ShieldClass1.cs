using Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ship.ShieldsAndHulls.Shields;

public sealed class ShieldClass1 : BaseShield
{
    private const int ShieldsHp = 10;
    public ShieldClass1()
        : base(ShieldsHp)
    {
    }

    public override int GetDamage(BaseObstacle? obstacle)
    {
        int obstacleDamage = obstacle?.Damage ?? 0;
        return obstacleDamage * obstacle switch
        {
            Asteroid => 5,
            Meteorite => 2,
            _ => 1,
        };
    }
}