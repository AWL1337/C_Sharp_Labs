using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Drive;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Factories;

public class SeagateBarracudaSt2000Factory : DriveFactory
{
    private const string Name = "SeagateBarracudaSt2000";
    private const int Capacity = 256;
    private const int RotateSpeed = 510;
    private const int Consumption = 70;

    public override Hdd CreateDrive()
    {
        return new Hdd(Name, Capacity, RotateSpeed, Consumption);
    }
}