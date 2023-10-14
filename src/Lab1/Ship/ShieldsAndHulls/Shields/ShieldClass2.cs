using Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ship.ShieldsAndHulls.Shields;

public sealed class ShieldClass2 : BaseShield
{
    private const int ShieldsHp = 30;
    public ShieldClass2()
        : base(ShieldsHp)
    {
    }

    public override int GetDamage(BaseObstacle? obstacle)
    {
        int obstacleDamage = obstacle?.Damage ?? 0;
        return obstacleDamage * obstacle switch
        {
            Asteroid => 3,
            Meteorite => 2,
            _ => 1,
        };
    }
}