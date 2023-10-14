using Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab1.Ship;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment;

public abstract class BaseEnvironment
{
    private readonly string errorMesage = "Distance cannot be less than 0.";
    private double _distance;
    protected BaseEnvironment(double fuelConsumptionRatio, double distance, BaseObstacle? obstacle)
    {
        FuelConsumptionRatio = fuelConsumptionRatio;
        Distance = distance;
        Obstacle = obstacle;
    }

    public double FuelConsumptionRatio { get; }
    public double Distance
    {
        get => _distance;
        private set
        {
            if (value < 0)
            {
                throw new WrongEnvironmentDistanceException(errorMesage);
            }

            _distance = value;
        }
    }

    public BaseObstacle? Obstacle { get; private set; }

    public abstract bool Pass(BaseShip ship);

    public abstract void CalculatePriceOfFlight(BaseShip ship);
}