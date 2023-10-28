using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.RAM;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.XMP;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Factories;

public class AmdRadeonR7Factory : IRamFactory
{
    private const string Name = "AmdRadeonR7";
    private const int MemoryAmount = 8192;
    private const int MemoryFrequency = 2666;
    private const double Voltage = 1.2;
    private const string FormFactor = "DIMM";
    private const int DdrVersion = 4;
    private const int Consumption = 25;
    private static readonly IReadOnlyCollection<XmpProfile> AvailableProfiles = new Collection<XmpProfile>() { new R7Factory().CreateXmpProfile() };

    public Ram CreateRam()
    {
        return new Ram(Name, MemoryAmount, MemoryFrequency, Voltage, AvailableProfiles, FormFactor, DdrVersion, Consumption);
    }
}