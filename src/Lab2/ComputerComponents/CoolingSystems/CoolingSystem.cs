using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.CoolingSystems;

public class CoolingSystem : ComputerComponent
{
    public CoolingSystem(string name, int height, IReadOnlyCollection<string> compatibleSockets, int maxTdp)
        : base(name)
    {
        Height = height;
        CompatibleSockets = compatibleSockets;
        MaxTdp = maxTdp;
    }

    private CoolingSystem(CoolingSystem coolingSystem)
        : base(coolingSystem.Name)
    {
        Height = coolingSystem.Height;
        CompatibleSockets = coolingSystem.CompatibleSockets;
        MaxTdp = coolingSystem.MaxTdp;
    }

    public int Height { get; set; }
    public IReadOnlyCollection<string> CompatibleSockets { get; set; }
    public int MaxTdp { get; set; }

    public override CoolingSystem Clone()
    {
        return new CoolingSystem(this);
    }
}