using Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Ship.Engines.ImpulseEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Ship.Engines.JumpEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Ship.ShieldsAndHulls;
using Itmo.ObjectOrientedProgramming.Lab1.Ship.ShieldsAndHulls.Hulls;
using Itmo.ObjectOrientedProgramming.Lab1.Ship.ShieldsAndHulls.Shields;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ship;

public abstract class BaseShip
{
    private const double ImpulseFuelCost = 33;
    private const double JumpFuelCost = 1000;
    private const double ZeroFuelWasted = 0;
    private const int NoFlares = 0;
    private const int NoFShield = 0;

    protected BaseShip(BaseHull hull, BaseShield? shield, BaseImpulseEngine impulseEngine, BaseJumpEngine? jumpEngine, PhotonShield? photonShield, AntiNeutrinoEmitter? neutrinoEmitter, double massRatio)
    {
        ShipHealth = new HealthBlock(hull, shield, photonShield, neutrinoEmitter);
        ImpulseEngine = impulseEngine;
        JumpEngine = jumpEngine;
        MassRatio = massRatio;
    }

    public double MassRatio { get; }
    public double FlightCost { get; private set; }
    public bool IsPassed { get; set; }
    public HealthBlock ShipHealth { get; }
    public BaseImpulseEngine ImpulseEngine { get; }
    public BaseJumpEngine? JumpEngine { get; }

    public bool Collision(BaseObstacle? obstacle)
    {
        return ShipHealth.WillSurviveCollision(obstacle);
    }

    public bool IsActiveEmitter()
    {
        return ShipHealth.EmitterIsActive();
    }

    public int ShieldStatus()
    {
        return ShipHealth.Shield?.Durability ?? NoFShield;
    }

    public bool Flares(BaseObstacle? obstacle)
    {
        return ShipHealth.WillSurviveFlares(obstacle?.ObstacleAmount ?? NoFlares);
    }

    public double CalculateFuelOfImpulseFlight(double distance)
    {
        return ImpulseEngine.CalculateFuel(distance) * ImpulseFuelCost;
    }

    public double CalculateFuelOfJumpFlight(double distance)
    {
        return JumpEngine?.CalculateFuel(distance) ?? ZeroFuelWasted;
    }

    public void CalculatePriceOfJumpFlight(double amountOfFuel)
    {
        FlightCost += amountOfFuel * MassRatio * JumpFuelCost;
    }

    public void CalculatePriceOfImpulseFlight(double amountOfFuel)
    {
        FlightCost += amountOfFuel * MassRatio * ImpulseFuelCost;
    }
}