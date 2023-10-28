using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.BIOS;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Chipsets;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.MotherBoards;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Factories;

public class MsiA520MFactory : IMotherBoardFactory
{
   private const string Name = "MsiA520M";
   private const string Socket = "AM4";
   private const int PcieAmount = 1;
   private const int SataAmount = 4;
   private const int DdrStandart = 4;
   private const int RamSlots = 2;
   private const string FormFactor = "mATX";
   private static readonly Chipset Chipset = new Amd520MFactory().CreateChipset();
   private static readonly Bios Bios = new W25Q128Factory().CreateBios();

   public MotherBoard CreateMotherBoard()
   {
      return new MotherBoard(Name, Socket, PcieAmount, SataAmount, Chipset, DdrStandart, RamSlots, FormFactor, Bios);
   }
}