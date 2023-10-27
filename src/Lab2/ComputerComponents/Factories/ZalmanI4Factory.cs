using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Cases;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Factories;

public class ZalmanI4Factory : IComputerCaseFactory
{
    private const string Name = "ZalmanI4";
    private const int MaxHeight = 320;
    private const int MaxWidth = 150;
    private const int CaseHeight = 396;
    private const int CaseLenght = 484;
    private const int CaseWidth = 225;
    private const string MotherBoardFormFactor = "mATX";

    public ComputerCase CreateComputerCase()
    {
        return new ComputerCase(Name, MaxHeight, MaxWidth, CaseHeight, CaseLenght, CaseWidth, MotherBoardFormFactor);
    }
}