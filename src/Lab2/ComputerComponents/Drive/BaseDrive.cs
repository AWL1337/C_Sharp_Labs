namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Drive;

public abstract class BaseDrive : ComputerComponent
{
    protected BaseDrive(string name)
        : base(name)
    {
    }

    public abstract int ComponentConsumption();
}