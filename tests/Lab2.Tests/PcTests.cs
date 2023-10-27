using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.CoolingSystems;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.CPU;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.PowerPacks;
using Itmo.ObjectOrientedProgramming.Lab2.Computers;
using Itmo.ObjectOrientedProgramming.Lab2.Service;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class PcTests
{
    [Fact]
    public void SuccessfulAssemblingTest()
    {
        Computer computer = new RogPc().SetConfigurator(new ComputerConfigurator()).Build();
        (Result Result, IEnumerable<string> Log) valid = new Validator().CheckPc(computer);
        Assert.True(valid.Result is Result.Success);
    }

    [Fact]
    public void OutOfWarrantyAssemblingTest()
    {
        var repo = new Repository();
        var director = new RogPc();
        ComputerConfigurator computerbuilder = director.SetConfigurator(new ComputerConfigurator());
        computerbuilder.PowerPack = (PowerPack)repo.Get("PowerPacks").Where(obj => obj.Name == "AerocoolVx").First();
        (Result Result, IEnumerable<string> Log) valid = new Validator().CheckPc(computerbuilder.Build());
        Assert.True(valid.Result is Result.OutOfWarranty);
    }

    [Fact]
    public void OutOfWarrantyCoolingSystemAssemblingTest()
    {
        var repo = new Repository();
        var director = new RogPc();
        ComputerConfigurator computerbuilder = director.SetConfigurator(new ComputerConfigurator());
        computerbuilder.CoolingSystem = (CoolingSystem)repo.Get("CoolingSystem").Where(obj => obj.Name == "DeepCoolTheta").First();
        (Result Result, IEnumerable<string> Log) valid = new Validator().CheckPc(computerbuilder.Build());
        Assert.True(valid.Result is Result.OutOfWarranty);
    }

    [Fact]
    public void FailAssemblingTest()
    {
        var repo = new Repository();
        var director = new RogPc();
        ComputerConfigurator computerbuilder = director.SetConfigurator(new ComputerConfigurator());
        computerbuilder.Cpu = (Cpu)repo.Get("CPU").Where(obj => obj.Name == "AmdRyzen75700G").First();
        (Result Result, IEnumerable<string> Log) valid = new Validator().CheckPc(computerbuilder.Build());
        Assert.True(valid.Result is Result.Fail);
    }
}