using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Factories;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public class Repository
{
    private Dictionary<string, List<ComputerComponent>> _repo = new Dictionary<string, List<ComputerComponent>>();
    public Repository()
    {
        _repo.Add("CPU", new List<ComputerComponent>() { new AmdRyzen55600GFactory().CreateCpu(), new AmdRyzen75700GFactory().CreateCpu() });
        _repo.Add("GPU", new List<ComputerComponent>() { new Rtx4090Factory().CreateGpu() });
        _repo.Add("CoolingSystem", new List<ComputerComponent>() { new DeepCoolGammaFactory().CreateCoolingSystem(), new DeepCoolThetaFactory().CreateCoolingSystem() });
        _repo.Add("Motherboard", new List<ComputerComponent>() { new MsiA520MFactory().CreateMotherBoard() });
        _repo.Add("Chipset", new List<ComputerComponent>() { new AmdRyzen55600GFactory().CreateCpu(), new AmdRyzen75700GFactory().CreateCpu() });
        _repo.Add("Case", new List<ComputerComponent>() { new ZalmanI4Factory().CreateComputerCase() });
        _repo.Add("BIOS", new List<ComputerComponent>() { new W25Q128Factory().CreateBios() });
        _repo.Add("Drive", new List<ComputerComponent>() { new DigmaRunS9Factory().CreateDrive(), new SeagateBarracudaSt2000Factory().CreateDrive() });
        _repo.Add("PowerPacks", new List<ComputerComponent>() { new AerocoolVxFactory().CreatePowerPack(), new ThermaltakeGrandFactory().CreatePowerPack() });
        _repo.Add("RAM", new List<ComputerComponent>() { new AmdRadeonR7Factory().CreateRam() });
        _repo.Add("WifiAdapter", new List<ComputerComponent>() { new DexpWfaFactory().CreateAdapter() });
        _repo.Add("XMP", new List<ComputerComponent>() { new R7Factory().CreateXmpProfile() });
    }

    public void Add(string key, ComputerComponent component)
    {
        _repo[key].Add(component);
    }

    public IEnumerable<ComputerComponent> Get(string key)
    {
        return _repo[key];
    }
}