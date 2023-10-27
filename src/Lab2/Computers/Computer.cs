using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Cases;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.CoolingSystems;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.CPU;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Drive;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.GPU;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.MotherBoards;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.PowerPacks;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.RAM;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.WifiAdapters;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computers;

public class Computer
{
    public Computer(MotherBoard? motherBoard, Cpu? cpu, Ram? ram, CoolingSystem? coolingSystem, PowerPack? powerPack, Gpu? gpu, ComputerCase? computerCase, IReadOnlyCollection<BaseDrive>? drives, WifiAdapter? wifiAdapter)
    {
        MotherBoard = motherBoard;
        Cpu = cpu;
        Ram = ram;
        CoolingSystem = coolingSystem;
        PowerPack = powerPack;
        Gpu = gpu;
        ComputerCase = computerCase;
        Drives = drives;
        WifiAdapter = wifiAdapter;
    }

    public MotherBoard? MotherBoard { get; }
    public Cpu? Cpu { get; }
    public Ram? Ram { get; }
    public CoolingSystem? CoolingSystem { get; }
    public PowerPack? PowerPack { get; }
    public Gpu? Gpu { get; }
    public ComputerCase? ComputerCase { get; }
    public IReadOnlyCollection<BaseDrive>? Drives { get; }
    public WifiAdapter? WifiAdapter { get; }

    public int SummaryConsumption()
    {
        int consumption = 0;
        consumption += Cpu?.Consumption ?? 0;
        consumption += Ram?.Consumption ?? 0;
        consumption += Gpu?.Consumption ?? 0;
        consumption += Drives?.Sum(obj => obj.ComponentConsumption()) ?? 0;
        consumption += WifiAdapter?.Consumption ?? 0;
        return consumption;
    }

    public ComputerConfigurator Clone()
    {
        return new ComputerConfigurator(this);
    }
}