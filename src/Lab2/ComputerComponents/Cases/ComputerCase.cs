namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Cases;

public class ComputerCase : ComputerComponent
{
    public ComputerCase(string name, int maxHeight, int maxWidth, int caseHeight, int caseLenght, int caseWidth, string motherBoardFormFactor)
        : base(name)
    {
        MaxHeight = maxHeight;
        MaxWidth = maxWidth;
        CaseHeight = caseHeight;
        CaseLenght = caseLenght;
        CaseWidth = caseWidth;
        MotherBoardFormFactor = motherBoardFormFactor;
    }

    private ComputerCase(ComputerCase computerCase)
        : base(computerCase.Name)
    {
        MaxHeight = computerCase.MaxHeight;
        MaxWidth = computerCase.MaxWidth;
        CaseHeight = computerCase.CaseHeight;
        CaseLenght = computerCase.CaseLenght;
        CaseWidth = computerCase.CaseWidth;
        MotherBoardFormFactor = computerCase.MotherBoardFormFactor;
    }

    public int MaxHeight { get; set; }
    public int MaxWidth { get; set; }
    public int CaseHeight { get; set; }
    public int CaseLenght { get; set; }
    public int CaseWidth { get; set; }
    public string MotherBoardFormFactor { get; set; }

    public override ComputerCase Clone()
    {
        return new ComputerCase(this);
    }
}