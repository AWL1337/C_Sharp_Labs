using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.CoolingSystems;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Factories;

public class DeepCoolGammaFactory : ICoolingSystemFactory
{
    private const string Name = "DeepCoolGamma";
    private const int Height = 131;
    private const int MaxTdp = 100;
    private static readonly IReadOnlyCollection<string> CompatibleSockets = new Collection<string>() { "AM4" };

    public CoolingSystem CreateCoolingSystem()
    {
        return new CoolingSystem(Name, Height, CompatibleSockets, MaxTdp);
    }
}