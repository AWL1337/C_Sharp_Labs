namespace Itmo.ObjectOrientedProgramming.Lab1.Ship.Engines.JumpEngines;

public class JumpEngineGamma : BaseJumpEngine
{
    private const double LongDistance = 10000;
    private const double CommonFuelRatio = 268;
    public JumpEngineGamma()
        : base(LongDistance)
    {
    }

    public override double CalculateFuel(double distance)
    {
        return distance * distance * CommonFuelRatio;
    }
}