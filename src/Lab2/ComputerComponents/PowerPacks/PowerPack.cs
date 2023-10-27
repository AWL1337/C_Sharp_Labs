namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.PowerPacks;

public class PowerPack : ComputerComponent
{
    public PowerPack(string name, int consumptionLimit)
        : base(name)
    {
        ConsumptionLimit = consumptionLimit;
    }

    private PowerPack(PowerPack powerPack)
        : base(powerPack.Name)
    {
        ConsumptionLimit = powerPack.ConsumptionLimit;
    }

    public int ConsumptionLimit { get; set; }

    public override PowerPack Clone()
    {
        return new PowerPack(this);
    }
}