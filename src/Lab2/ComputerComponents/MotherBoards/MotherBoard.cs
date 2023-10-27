using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.BIOS;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Chipsets;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.MotherBoards;

public class MotherBoard : ComputerComponent
{
    public MotherBoard(string name, string socket, int pcieAmount, int sataAmount, Chipset chipset, int ddrStandart, int ramSlots, string formFactor, Bios bios)
        : base(name)
    {
        PcieAmount = pcieAmount;
        SataAmount = sataAmount;
        Socket = socket;
        RamSlots = ramSlots;
        DdrStandart = ddrStandart;
        MotherBoardChipset = chipset;
        FormFactor = formFactor;
        MotherBoardBios = bios;
    }

    private MotherBoard(MotherBoard motherBoard)
        : base(motherBoard.Name)
    {
        PcieAmount = motherBoard.PcieAmount;
        SataAmount = motherBoard.SataAmount;
        Socket = motherBoard.Socket;
        RamSlots = motherBoard.RamSlots;
        DdrStandart = motherBoard.DdrStandart;
        MotherBoardChipset = motherBoard.MotherBoardChipset.Clone();
        FormFactor = motherBoard.FormFactor;
        MotherBoardBios = motherBoard.MotherBoardBios.Clone();
    }

    public int PcieAmount { get; set; }
    public int SataAmount { get; set; }
    public Chipset MotherBoardChipset { get; set; }
    public int RamSlots { get; set; }
    public int DdrStandart { get; set; }
    public string Socket { get; set; }
    public string FormFactor { get; set; }
    public Bios MotherBoardBios { get; set; }

    public override MotherBoard Clone()
    {
        return new MotherBoard(this);
    }
}