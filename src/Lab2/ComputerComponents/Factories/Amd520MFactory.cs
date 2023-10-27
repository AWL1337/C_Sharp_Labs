using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Chipsets;
using Itmo.ObjectOrientedProgramming.Lab2.Service;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Factories;

public class Amd520MFactory : IChipsetFactory
{
    private const string Name = "Amd520M";
    private static readonly IReadOnlyCollection<int> MemoryFrequencies = new Collection<int>() { 1866, 2133, 2400, 2667, 2800 };
    public Chipsets.Chipset CreateChipset()
    {
        return new Chipsets.Chipset(Name, new XmpSupport(), MemoryFrequencies);
    }
}