namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Drive;

public class Hdd : BaseDrive
{
    public Hdd(string name, int capacity, int rotateSpeed, int consumption)
        : base(name)
    {
        Capacity = capacity;
        RotateSpeed = rotateSpeed;
        Consumption = consumption;
    }

    private Hdd(Hdd hdd)
        : base(hdd.Name)
    {
        Capacity = hdd.Capacity;
        RotateSpeed = hdd.RotateSpeed;
        Consumption = hdd.Consumption;
    }

    public int Capacity { get; set; }
    public int RotateSpeed { get; set; }
    public int Consumption { get; set; }

    public override Hdd Clone()
    {
        return new Hdd(this);
    }

    public override int ComponentConsumption()
    {
        return Consumption;
    }
}