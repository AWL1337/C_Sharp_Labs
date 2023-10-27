using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Cases;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.CoolingSystems;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.CPU;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Drive;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.GPU;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.MotherBoards;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.PowerPacks;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.RAM;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.WifiAdapters;
using Itmo.ObjectOrientedProgramming.Lab2.Service.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computers;

public class ComputerConfigurator
{
    public ComputerConfigurator(Computer computer)
    {
        MotherBoard = computer?.MotherBoard;
        Cpu = computer?.Cpu;
        Ram = computer?.Ram;
        CoolingSystem = computer?.CoolingSystem;
        PowerPack = computer?.PowerPack;
        Gpu = computer?.Gpu;
        ComputerCase = computer?.ComputerCase;
        Drives = computer?.Drives;
        WifiAdapter = computer?.WifiAdapter;
    }

    public ComputerConfigurator()
    {
    }

    public MotherBoard? MotherBoard { get; set; }
    public Cpu? Cpu { get; set; }
    public Ram? Ram { get; set; }
    public CoolingSystem? CoolingSystem { get; set; }
    public PowerPack? PowerPack { get; set; }
    public Gpu? Gpu { get; set; }
    public ComputerCase? ComputerCase { get; set; }
    public IReadOnlyCollection<BaseDrive>? Drives { get; set; }
    public WifiAdapter? WifiAdapter { get; set; }

    public Computer Build()
    {
        return new Computer(
            MotherBoard ?? throw new NoMotherBoardException(),
            Cpu ?? throw new NoCpuException(),
            Ram ?? throw new NoRamException(),
            CoolingSystem ?? throw new NoCoolingSystemException(),
            PowerPack ?? throw new NoPowerPackException(),
            Gpu,
            ComputerCase ?? throw new NoComputerCaseException(),
            Drives ?? throw new NoDriveException(),
            WifiAdapter);
    }
}