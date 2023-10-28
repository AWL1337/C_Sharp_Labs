using Itmo.ObjectOrientedProgramming.Lab2.Service;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.WifiAdapters;

public class WifiAdapter : ComputerComponent
{
    public WifiAdapter(string name, double wifiVersion, BluetoothModule? module, double pcieVersion, int consumption)
        : base(name)
    {
        WifiVersion = wifiVersion;
        ComputerBluetoothModule = module;
        PcieVersion = pcieVersion;
        Consumption = consumption;
    }

    private WifiAdapter(WifiAdapter wifiAdapter)
        : base(wifiAdapter.Name)
    {
        WifiVersion = wifiAdapter.WifiVersion;
        ComputerBluetoothModule = wifiAdapter.ComputerBluetoothModule;
        PcieVersion = wifiAdapter.PcieVersion;
        Consumption = wifiAdapter.Consumption;
    }

    public double WifiVersion { get; set; }
    public BluetoothModule? ComputerBluetoothModule { get; set; }
    public double PcieVersion { get; set; }
    public int Consumption { get; set; }

    public override WifiAdapter Clone()
    {
        return new WifiAdapter(this);
    }
}