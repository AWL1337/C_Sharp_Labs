namespace Itmo.ObjectOrientedProgramming.Lab4.OutputSystem;

public class Console : IOutputSystem
{
    public void Show(string text)
    {
        System.Console.Write(text);
    }
}