using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.PowerPacks;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Factories;

public class AerocoolVxFactory : IPowerPackFactory
{
    private const string Name = "AerocoolVx";
    private const int PowerLimit = 750;
    public PowerPack CreatePowerPack()
    {
        return new PowerPack(Name, PowerLimit);
    }
}