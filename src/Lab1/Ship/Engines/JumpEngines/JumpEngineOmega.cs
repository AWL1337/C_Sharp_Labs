namespace Itmo.ObjectOrientedProgramming.Lab1.Ship.Engines.JumpEngines;

public class JumpEngineOmega : BaseJumpEngine
{
    private const double MiddleDistance = 1000;
    private const double CommonFuelRatio = 107;
    public JumpEngineOmega()
        : base(MiddleDistance)
    {
    }

    public override double CalculateFuel(double distance)
    {
        return distance * double.Log(distance) * CommonFuelRatio;
    }
}