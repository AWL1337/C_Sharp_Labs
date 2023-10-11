namespace Itmo.ObjectOrientedProgramming.Lab1.Ship.Engines.JumpEngines;

public abstract class BaseJumpEngine
{
    protected BaseJumpEngine(double maxLenght)
    {
        MaxLenght = maxLenght;
    }

    public double MaxLenght { get; set; }
    public abstract double CalculateFuel(double distance);
}