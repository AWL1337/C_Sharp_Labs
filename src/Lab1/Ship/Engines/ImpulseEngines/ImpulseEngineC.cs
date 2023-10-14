namespace Itmo.ObjectOrientedProgramming.Lab1.Ship.Engines.ImpulseEngines;

public class ImpulseEngineC : BaseImpulseEngine
{
    private const double CommonFuelRatio = 103;
    public override double CalculateFuel(double distance)
    {
        return distance * CommonFuelRatio;
    }
}