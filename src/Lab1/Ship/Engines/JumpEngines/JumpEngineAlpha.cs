namespace Itmo.ObjectOrientedProgramming.Lab1.Ship.Engines.JumpEngines;

public class JumpEngineAlpha : BaseJumpEngine
{
    private const double ShortDistance = 100;
    private const double CommonFuelRatio = 56;
    public JumpEngineAlpha()
        : base(ShortDistance)
    {
    }

    public override double CalculateFuel(double distance)
    {
        return distance * CommonFuelRatio;
    }
}