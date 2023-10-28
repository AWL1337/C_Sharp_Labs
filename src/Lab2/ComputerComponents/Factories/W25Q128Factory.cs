using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.BIOS;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Factories;

public class W25Q128Factory : IBiosFactory
{
    private const string Name = "W25Q128";
    private const string Type = "AMI";
    private const double Version = 2.1;

    private static readonly IReadOnlyCollection<string> CompatibleProcessors = new Collection<string>() { "AmdRyzen55600G" };

    public Bios CreateBios()
    {
        return new Bios(Name, Type, Version, CompatibleProcessors);
    }
}