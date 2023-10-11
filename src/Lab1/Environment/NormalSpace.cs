using Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab1.Ship;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment;

public sealed class NormalSpace : BaseEnvironment
{
    private const double FuelRatio = 1;
    private readonly string errorMesage = "Here can be only Asteroids or Meteorites";
    public NormalSpace(double distance, BaseObstacle? obstacle = null)
        : base(FuelRatio, distance, obstacle)
    {
        if (obstacle is not Asteroid && obstacle is not Meteorite && obstacle is not null)
        {
            throw new WrongObstacleException(errorMesage);
        }
    }

    public override bool Pass(BaseShip ship)
    {
        CalculatePriceOfFlight(ship);
        return ship.Collision(Obstacle);
    }

    public override void CalculatePriceOfFlight(BaseShip ship)
    {
        ship.CalculatePriceOfImpulseFlight(ship.CalculateFuelOfImpulseFlight(Distance) * FuelConsumptionRatio);
    }
}