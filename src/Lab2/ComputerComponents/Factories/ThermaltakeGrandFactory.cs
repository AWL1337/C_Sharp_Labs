using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.PowerPacks;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Factories;

public class ThermaltakeGrandFactory : IPowerPackFactory
{
    private const string Name = "ThermaltakeGrand";
    private const int PowerLimit = 1500;

    public PowerPack CreatePowerPack()
    {
        return new PowerPack(Name, PowerLimit);
    }
}