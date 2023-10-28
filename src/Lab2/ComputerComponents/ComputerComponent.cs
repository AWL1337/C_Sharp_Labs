namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents;

public abstract class ComputerComponent
{
    protected ComputerComponent(string name) => Name = name;
    public string Name { get; }
    public abstract ComputerComponent Clone();
}