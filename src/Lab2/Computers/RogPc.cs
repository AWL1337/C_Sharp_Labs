using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Drive;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Factories;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computers;

public class RogPc : IPcPreset
{
    public ComputerBuilder SetConfigurator(ComputerBuilder builder)
    {
        if (builder is null)
        {
            return new ComputerBuilder();
        }

        builder.Cpu = new AmdRyzen55600GFactory().CreateCpu();
        builder.Drives = new List<BaseDrive>() { new SeagateBarracudaSt2000Factory().CreateDrive() };
        builder.MotherBoard = new MsiA520MFactory().CreateMotherBoard();
        builder.Gpu = new Rtx4090Factory().CreateGpu();
        builder.CoolingSystem = new DeepCoolGammaFactory().CreateCoolingSystem();
        builder.Ram = new AmdRadeonR7Factory().CreateRam();
        builder.ComputerCase = new ZalmanI4Factory().CreateComputerCase();
        builder.PowerPack = new ThermaltakeGrandFactory().CreatePowerPack();
        return builder;
    }
}