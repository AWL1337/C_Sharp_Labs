namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.XMP;

public class XmpProfile : ComputerComponent
{
    public XmpProfile(string name, string timing, double voltage, int frequency)
        : base(name)
    {
        Timing = timing;
        Voltage = voltage;
        Frequency = frequency;
    }

    private XmpProfile(XmpProfile xmpProfile)
        : base(xmpProfile.Name)
    {
        Timing = xmpProfile.Timing;
        Voltage = xmpProfile.Voltage;
        Frequency = xmpProfile.Frequency;
    }

    public string Timing { get; set; }
    public double Voltage { get; set; }
    public int Frequency { get; set; }
    public override ComputerComponent Clone()
    {
        return new XmpProfile(this);
    }
}