using Application.UiCommands;
using Controllers;
using Controllers.Results;
using Spectre.Console;

namespace Application;

public class App
{
    public ControllersAccessPoint AccessPoint { get; } = new ControllersAccessPoint();

    public void Run()
    {
        while (true)
        {
            IEnumerable<string> opt = AccessPoint.Options();
            string chosenOption =
                AnsiConsole.Prompt(new SelectionPrompt<string>().Title("Choose Option").PageSize(5).AddChoices(opt));
            UiFrame frame = Mapping.MapFrame(chosenOption);
            BaseOutput result = AccessPoint.Run(frame.Run());
            frame.Response(result);
        }
    }
}