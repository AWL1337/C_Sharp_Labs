using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.XMP;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.RAM;

public class Ram : ComputerComponent
{
    public Ram(string name, int memoryAmount, int memoryFrequency, double voltage, IReadOnlyCollection<XmpProfile> availableProfiles, string formFactor, int ddrVersion, int consumption)
        : base(name)
    {
        MemoryAmount = memoryAmount;
        MemoryFrequency = memoryFrequency;
        Voltage = voltage;
        AvailableProfiles = availableProfiles;
        FormFactor = formFactor;
        DdrVersion = ddrVersion;
        Consumption = consumption;
    }

    private Ram(Ram ram)
        : base(ram.Name)
    {
        MemoryAmount = ram.MemoryAmount;
        MemoryFrequency = ram.MemoryFrequency;
        Voltage = ram.Voltage;
        AvailableProfiles = (IReadOnlyCollection<XmpProfile>)ram.AvailableProfiles.Select(x => x.Clone()).ToList();
        FormFactor = ram.FormFactor;
        DdrVersion = ram.DdrVersion;
        Consumption = ram.Consumption;
    }

    public int MemoryAmount { get; set; }
    public int MemoryFrequency { get; set; }
    public int DdrVersion { get; set; }
    public int Consumption { get; set; }
    public double Voltage { get; set; }
    public string FormFactor { get; set; }
    public IReadOnlyCollection<XmpProfile> AvailableProfiles { get; set; }

    public override Ram Clone()
    {
        return new Ram(this);
    }
}