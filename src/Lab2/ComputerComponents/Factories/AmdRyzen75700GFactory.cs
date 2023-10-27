using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.CPU;
using Itmo.ObjectOrientedProgramming.Lab2.Service;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Factories;

public class AmdRyzen75700GFactory : ICpuFactory
{
    private const double CoreFrequency = 3.8;
    private const int CoreAmount = 8;
    private const string Socket = "AM4";
    private const string Name = "AmdRyzen75700G";
    private const int Tdp = 65;
    private const int Consumption = 130;
    private static readonly IReadOnlyCollection<int> MemoryFrequencies = new Collection<int>() { 3200 };

    public Cpu CreateCpu()
    {
        return new Cpu(Name, CoreFrequency, CoreAmount, new GpuCore(), Socket, MemoryFrequencies, Tdp, Consumption);
    }
}