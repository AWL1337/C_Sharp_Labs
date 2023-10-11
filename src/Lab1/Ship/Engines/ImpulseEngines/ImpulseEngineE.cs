namespace Itmo.ObjectOrientedProgramming.Lab1.Ship.Engines.ImpulseEngines;

public class ImpulseEngineE : BaseImpulseEngine
{
    private const double CommonFuelRatio = 1070;
    public override double CalculateFuel(double distance)
    {
        return double.Pow(distance, double.E) * CommonFuelRatio;
    }
}