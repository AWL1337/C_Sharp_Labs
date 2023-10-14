using Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Ship.ShieldsAndHulls.Hulls;
using Itmo.ObjectOrientedProgramming.Lab1.Ship.ShieldsAndHulls.Shields;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ship.ShieldsAndHulls;

public class HealthBlock
{
    public HealthBlock(BaseHull stockHull, BaseShield? stockShield, PhotonShield? photonShield, AntiNeutrinoEmitter? neutrinoEmitter)
    {
        Hull = stockHull;
        Shield = stockShield;
        PhotonShield = photonShield;
        NeutrinoEmitter = neutrinoEmitter;
    }

    public BaseHull Hull { get; set; }
    public BaseShield? Shield { get; set; }
    public PhotonShield? PhotonShield { get; private set; }
    public AntiNeutrinoEmitter? NeutrinoEmitter { get; private set; }

    public bool WillSurviveFlares(int amount)
    {
        if (PhotonShield is null)
        {
            return false;
        }

        PhotonShield.TakeDamage(amount);
        return PhotonShield.IsActive();
    }

    public bool EmitterIsActive()
    {
        return NeutrinoEmitter is not null;
    }

    public bool WillSurviveCollision(BaseObstacle? obstacle)
    {
        if (obstacle is null)
        {
            return true;
        }

        if (Shield is null || !Shield.IsActive())
        {
            Hull.CalculateDamage(obstacle);
            return Hull.IsNotCrushed();
        }

        Shield.TakeDamage(obstacle, Shield.AmountOfStoppedObstacles(obstacle));
        if (Shield.IsActive())
        {
            Hull.CalculateDamage(obstacle, Shield.TakeDamage(obstacle));
            return Hull.IsNotCrushed();
        }

        Hull.CalculateDamage(obstacle);
        return Hull.IsNotCrushed();
    }
}