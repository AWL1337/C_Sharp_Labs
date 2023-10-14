using System;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ship.ShieldsAndHulls.Hulls;

public abstract class BaseHull
{
    private const int CrushedHull = 0;
    private const double AdditionalDamageRatio = 0.33;

    protected BaseHull(int durability)
    {
        Durability = durability;
    }

    public int Durability { get; private set; }

    public bool IsNotCrushed()
    {
        return Durability >= CrushedHull;
    }

    public void CalculateDamage(BaseObstacle? obstacle, int additionalDamage = 0)
    {
        if (additionalDamage < 0)
        {
            throw new ArgumentException(string.Empty);
        }

        if (obstacle is null)
        {
            return;
        }

        Durability -= (int)(additionalDamage * AdditionalDamageRatio);
        Durability -= GetDamage(obstacle) * obstacle.ObstacleAmount;
        obstacle.Crush(obstacle.ObstacleAmount);
    }

    public abstract int GetDamage(BaseObstacle? obstacle);
}