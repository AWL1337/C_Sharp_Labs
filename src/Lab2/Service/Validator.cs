using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Computers;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service;

public class Validator
{
    private const string WarrantyCoolingWarning = "CoolingSystem hasn't enough power";
    private const string WarrantyPowerWarning = "PowerPack hasn't enough power";
    private const string PowerError = "PowerPack is too weak";
    private const string CaseCoolingSystemError = "CoolingSystem is not compatible with ComputerCase";
    private const string CaseVideoCardError = "VideoCard is not compatible with ComputerCase";
    private const string CaseMotherError = "Motherboard is not compatible with ComputerCase";
    private const string SocketError = "CPU socket and board are not compatible";
    private const string RamError = "Cpu and Ram frequencies are not compatible";
    private const string NoGpuCore = "Cpu has no GpuCore and Computer has no VideoCard";
    private const string CoolingSystemSocketError = "CPU socket and CoolingSystem are not compatible";
    private const string CoolingSystemTdpError = "CPU cannot be cooled down by CoolingSystem";
    private const string BiosError = "CPU and board Bios are not compatible";
    private const double Coefficient = 0.85;

    public Validator() => Log = new Collection<string>();

    public Collection<string> Log { get; }

    public (Result Result, IEnumerable<string> Log) CheckPc(Computer computer)
    {
        if (!RequredValidation(computer))
        {
            return (Result.Fail, Log);
        }

        if (computer is null)
        {
            return (Result.Fail, Log);
        }

        if (!WarrantyValidation(computer))
        {
            return (Result.OutOfWarranty, Log);
        }

        return (Result.Success, Log);
    }

    private bool RequredValidation(Computer computer)
    {
        bool passFlag = true;

        if (computer is null)
        {
            return false;
        }

        if (computer.Cpu?.Socket != computer.MotherBoard?.Socket)
        {
            Log.Add(SocketError);
            passFlag = false;
        }

        if (!computer.MotherBoard?.MotherBoardBios.CompatibleProcessors.Contains(computer.Cpu?.Name) ?? false)
        {
            Log.Add(BiosError);
            passFlag = false;
        }

        if (!computer.CoolingSystem?.CompatibleSockets.Contains(computer.Cpu?.Socket) ?? false)
        {
            Log.Add(CoolingSystemSocketError);
            passFlag = false;
        }

        if (computer.CoolingSystem?.MaxTdp < computer.Cpu?.Tdp * Coefficient)
        {
            Log.Add(CoolingSystemTdpError);
            passFlag = false;
        }

        if (computer.Cpu?.MemoryFrequencies.Max() < computer.Ram?.MemoryFrequency)
        {
            Log.Add(RamError);
            passFlag = false;
        }

        if (computer.Cpu?.Core is null && computer.Gpu is null)
        {
            Log.Add(NoGpuCore);
            passFlag = false;
        }

        if (computer.MotherBoard?.FormFactor != computer.ComputerCase?.MotherBoardFormFactor)
        {
            Log.Add(CaseMotherError);
            passFlag = false;
        }

        if (computer.Gpu?.Width > computer.ComputerCase?.CaseLenght)
        {
            Log.Add(CaseVideoCardError);
            passFlag = false;
        }

        if (computer.CoolingSystem?.Height > computer.ComputerCase?.CaseWidth)
        {
            Log.Add(CaseCoolingSystemError);
            passFlag = false;
        }

        if (computer.CoolingSystem?.Height > computer.ComputerCase?.CaseWidth)
        {
            Log.Add(CaseCoolingSystemError);
            passFlag = false;
        }

        if (computer.SummaryConsumption() * Coefficient > computer.PowerPack?.ConsumptionLimit)
        {
            Log.Add(PowerError);
            passFlag = false;
        }

        return passFlag;
    }

    private bool WarrantyValidation(Computer computer)
    {
        bool warrantyFlag = true;
        if (computer.SummaryConsumption() > computer.PowerPack?.ConsumptionLimit)
        {
            warrantyFlag = false;
            Log.Add(WarrantyPowerWarning);
        }

        if (computer.Cpu?.Tdp > computer.CoolingSystem?.MaxTdp)
        {
            warrantyFlag = false;
            Log.Add(WarrantyCoolingWarning);
        }

        return warrantyFlag;
    }
}