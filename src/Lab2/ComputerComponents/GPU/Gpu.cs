namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.GPU;

public class Gpu : ComputerComponent
{
    public Gpu(string name, int height, int width, double versionPcie, int chipFrequency, int consumption)
        : base(name)
    {
        Height = height;
        Width = width;
        VersionPcie = versionPcie;
        ChipFrequency = chipFrequency;
        Consumption = consumption;
    }

    private Gpu(Gpu gpu)
        : base(gpu.Name)
    {
        Height = gpu.Height;
        Width = gpu.Width;
        VersionPcie = gpu.VersionPcie;
        ChipFrequency = gpu.ChipFrequency;
        Consumption = gpu.Consumption;
    }

    public int Height { get; set; }
    public int Width { get; set; }
    public double VersionPcie { get; set; }
    public int ChipFrequency { get; set; }
    public int Consumption { get; set; }

    public override Gpu Clone()
    {
        return new Gpu(this);
    }
}