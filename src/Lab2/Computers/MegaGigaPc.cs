using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Drive;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Factories;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computers;

public class MegaGigaPc : IPcPreset
{
    public ComputerConfigurator SetPc(ComputerConfigurator configurator)
    {
        if (configurator is null)
        {
            return new ComputerConfigurator();
        }

        configurator.Cpu = new AmdRyzen55600GFactory().CreateCpu();
        configurator.Drives = new List<BaseDrive>() { new SeagateBarracudaSt2000Factory().CreateDrive() };
        configurator.MotherBoard = new MsiA520MFactory().CreateMotherBoard();
        configurator.Gpu = new Rtx4090Factory().CreateGpu();
        configurator.CoolingSystem = new DeepCoolGammaFactory().CreateCoolingSystem();
        configurator.Ram = new AmdRadeonR7Factory().CreateRam();
        configurator.ComputerCase = new ZalmanI4Factory().CreateComputerCase();
        configurator.PowerPack = new ThermaltakeGrandFactory().CreatePowerPack();
        return configurator;
    }
}