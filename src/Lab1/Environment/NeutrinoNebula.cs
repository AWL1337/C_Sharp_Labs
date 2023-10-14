using Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab1.Ship;
using Itmo.ObjectOrientedProgramming.Lab1.Ship.Engines.ImpulseEngines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment;

public class NeutrinoNebula : BaseEnvironment
{
    private const double FuelRatio = 1000;
    private const double RatioEngineE = 1.5;
    private readonly string errorMesage = "Here can be only Space Whale";
    public NeutrinoNebula(double distance, BaseObstacle? obstacle = null)
        : base(FuelRatio, distance, obstacle)
    {
        if (obstacle is not SpaceWhale && obstacle is not null)
        {
            throw new WrongObstacleException(errorMesage);
        }
    }

    public override bool Pass(BaseShip ship)
    {
        if (ship is not null)
        {
            CalculatePriceOfFlight(ship);

            return ship.IsActiveEmitter() || ship.Collision(Obstacle);
        }

        return false;
    }

    public override void CalculatePriceOfFlight(BaseShip ship)
    {
        double wastedFuel = ship?.CalculateFuelOfImpulseFlight(Distance) * FuelConsumptionRatio ?? 0;
        if (ship?.ImpulseEngine is ImpulseEngineE)
        {
            wastedFuel /= double.Pow(RatioEngineE, Distance);
        }

        ship?.CalculatePriceOfImpulseFlight(wastedFuel);
    }
}