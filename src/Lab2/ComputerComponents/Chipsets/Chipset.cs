using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Service;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Chipsets;

public class Chipset : ComputerComponent
{
    public Chipset(string name, XmpSupport? xmp, IReadOnlyCollection<int> memoryFrequencies)
        : base(name)
    {
        MemoryFrequencies = memoryFrequencies;
        Xmp = xmp;
    }

    private Chipset(Chipset chipset)
        : base(chipset.Name)
    {
        MemoryFrequencies = chipset.MemoryFrequencies;
        Xmp = chipset.Xmp;
    }

    public XmpSupport? Xmp { get; set; }
    public IReadOnlyCollection<int> MemoryFrequencies { get; set; }

    public override Chipset Clone()
    {
        return new Chipset(this);
    }
}