using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.WifiAdapters;
using Itmo.ObjectOrientedProgramming.Lab2.Service;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Factories;

public class DexpWfaFactory : IWifiAdapterFactory
{
    private const string Name = "DexpWfa";
    private const double WifiVersion = 1.2;
    private const double PcieVersion = 2.3;
    private const int Consumption = 30;

    public WifiAdapter CreateAdapter()
    {
        return new WifiAdapter(Name, WifiVersion, new BluetoothModule(), PcieVersion, Consumption);
    }
}