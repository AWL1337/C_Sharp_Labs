using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Drive;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Factories;

public class DigmaRunS9Factory : DriveFactory
{
    private const string Name = "DigmaRunS9";
    private const string Connection = "Sata";
    private const int Capacity = 256;
    private const int Speed = 510;
    private const int Consumption = 30;

    public override Ssd CreateDrive()
    {
        return new Ssd(Name, Connection, Capacity, Speed, Consumption);
    }
}