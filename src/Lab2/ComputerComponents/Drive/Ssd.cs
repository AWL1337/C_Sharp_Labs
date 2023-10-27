namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Drive;

public class Ssd : BaseDrive
{
    public Ssd(string name, string connection, int capacity, int speed, int consumption)
        : base(name)
    {
        Connection = connection;
        Capacity = capacity;
        Speed = speed;
        Consumption = consumption;
    }

    private Ssd(Ssd ssd)
        : base(ssd.Name)
    {
        Connection = ssd.Connection;
        Capacity = ssd.Capacity;
        Speed = ssd.Speed;
        Consumption = ssd.Consumption;
    }

    public string Connection { get; set; }
    public int Capacity { get; set; }
    public int Speed { get; set; }
    public int Consumption { get; set; }

    public override Ssd Clone()
    {
        return new Ssd(this);
    }

    public override int ComponentConsumption()
    {
        return Consumption;
    }
}