using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.BIOS;

public class Bios : ComputerComponent
{
    public Bios(string name, string type, double version, IReadOnlyCollection<string> compatibleProcessors)
        : base(name)
    {
        Type = type;
        Version = version;
        CompatibleProcessors = compatibleProcessors;
    }

    private Bios(Bios bios)
        : base(bios.Name)
    {
        Type = bios.Type;
        Version = bios.Version;
        CompatibleProcessors = bios.CompatibleProcessors;
    }

    public string Type { get; set; }
    public double Version { get; set; }
    public IReadOnlyCollection<string> CompatibleProcessors { get; set; }

    public override Bios Clone()
    {
        return new Bios(this);
    }
}