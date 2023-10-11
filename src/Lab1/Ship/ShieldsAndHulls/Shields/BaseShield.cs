using System;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ship.ShieldsAndHulls.Shields;

public abstract class BaseShield
{
    private const int DeactivatedShield = 0;
    private const int NoObstacles = 0;
    protected BaseShield(int durability)
    {
        Durability = durability;
    }

    public int Durability { get; set; }

    public bool IsActive()
    {
        return Durability > DeactivatedShield;
    }

    public int AmountOfStoppedObstacles(BaseObstacle? obstacle)
    {
        if (obstacle is null)
        {
            return NoObstacles;
        }

        return Durability / GetDamage(obstacle);
    }

    public int TakeDamage(BaseObstacle? obstacle, int amount = 1)
    {
        obstacle?.Crush(amount);

        int toReturn = Math.Abs(Durability -= GetDamage(obstacle) * amount);

        Durability = Durability < 0 ? 0 : Durability;

        return toReturn;
    }

    public abstract int GetDamage(BaseObstacle? obstacle);
}