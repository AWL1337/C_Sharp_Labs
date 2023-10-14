using Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab1.Ship;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment;

public class Nebula : BaseEnvironment
{
    private const double FuelRatio = 1;
    private readonly string errorMesage = "Here can be only Antimatter Flares";
    public Nebula(double distance, BaseObstacle? obstacle = null)
        : base(FuelRatio, distance, obstacle)
    {
        if (obstacle is not AntimatterFlares && obstacle is not null)
        {
            throw new WrongObstacleException(errorMesage);
        }
    }

    public override bool Pass(BaseShip ship)
    {
        CalculatePriceOfFlight(ship);

        if (ship?.JumpEngine is null || ship.JumpEngine.MaxLenght < Distance)
        {
            return false;
        }

        return ship.Flares(Obstacle);
    }

    public override void CalculatePriceOfFlight(BaseShip ship)
    {
        ship?.CalculatePriceOfJumpFlight(ship.CalculateFuelOfJumpFlight(Distance) * FuelConsumptionRatio);
    }
}