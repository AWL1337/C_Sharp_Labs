using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.GPU;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Factories;

public class Rtx4090Factory : IGpuFactory
{
    private const string Name = "Rtx4090";
    private const int Height = 290;
    private const int Width = 463;
    private const double VersionPcie = 4.0;
    private const int ChipFrequency = 21000;
    private const int Consumption = 600;

    public Gpu CreateGpu()
    {
        return new Gpu(Name, Height, Width, VersionPcie, ChipFrequency, Consumption);
    }
}