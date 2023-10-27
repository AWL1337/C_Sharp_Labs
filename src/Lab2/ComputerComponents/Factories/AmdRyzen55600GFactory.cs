using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.CPU;
using Itmo.ObjectOrientedProgramming.Lab2.Service;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Factories;

public class AmdRyzen55600GFactory : ICpuFactory
{
    private const double CoreFrequency = 3.9;
    private const int CoreAmount = 6;
    private const string Socket = "AM4";
    private const string Name = "AmdRyzen55600G";
    private const int Tdp = 65;
    private const int Consumption = 100;
    private static readonly IReadOnlyCollection<int> MemoryFrequencies = new Collection<int>() { 3200 };

    public Cpu CreateCpu()
    {
        return new Cpu(Name, CoreFrequency, CoreAmount, new GpuCore(), Socket, MemoryFrequencies, Tdp, Consumption);
    }
}