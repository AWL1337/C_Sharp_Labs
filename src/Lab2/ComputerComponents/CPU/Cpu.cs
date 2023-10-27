using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Service;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.CPU;

public class Cpu : ComputerComponent
{
    public Cpu(string name, double coreFrequency, int coreAmount, GpuCore? core, string socket, IReadOnlyCollection<int> memoryFrequencies, int tdp, int consumption)
        : base(name)
    {
        MemoryFrequencies = memoryFrequencies;
        CoreFrequency = coreFrequency;
        CoreAmount = coreAmount;
        Socket = socket;
        Core = core;
        Tdp = tdp;
        Consumption = consumption;
    }

    private Cpu(Cpu cpu)
        : base(cpu.Name)
    {
        MemoryFrequencies = cpu.MemoryFrequencies;
        CoreFrequency = cpu.CoreFrequency;
        CoreAmount = cpu.CoreAmount;
        Socket = cpu.Socket;
        Core = cpu.Core;
        Tdp = cpu.Tdp;
        Consumption = cpu.Consumption;
    }

    public double CoreFrequency { get; set; }
    public int CoreAmount { get; set; }
    public int Tdp { get; set; }
    public int Consumption { get; set; }
    public string Socket { get; set; }
    public GpuCore? Core { get; set; }
    public IReadOnlyCollection<int> MemoryFrequencies { get; set; }

    public override Cpu Clone()
    {
        return new Cpu(this);
    }
}