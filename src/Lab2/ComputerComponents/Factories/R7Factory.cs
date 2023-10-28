using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.XMP;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Factories;

public class R7Factory : IXmpFactory
{
    private const string Name = "R7";
    private const string Timing = "16-18-18-35";
    private const double Voltage = 1.4;
    private const int Frequency = 2666;
    public XmpProfile CreateXmpProfile()
    {
        return new XmpProfile(Name, Timing, Voltage, Frequency);
    }
}