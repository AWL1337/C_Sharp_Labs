using Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ship.ShieldsAndHulls.Shields;

public sealed class ShieldClass3 : BaseShield
{
    private const int ShieldsHp = 1000;
    public ShieldClass3()
        : base(ShieldsHp)
    {
    }

    public override int GetDamage(BaseObstacle? obstacle)
    {
        int obstacleDamage = obstacle?.Damage ?? 0;
        return obstacleDamage * obstacle switch
        {
            Asteroid => 25,
            Meteorite => 20,
            _ => 1,
        };
    }
}