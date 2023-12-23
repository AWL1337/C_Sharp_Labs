using Controllers.Requests;
using Controllers.Requests.RegisterRequests;
using Controllers.Results;
using Spectre.Console;

namespace Application.UiCommands;

public class QuitFrame : UiFrame
{
    public override BaseRequest Run()
    {
        return new QuitRequest(AnsiConsole.Confirm("Do you want to quit?"));
    }

    public override void Response(BaseOutput output)
    {
        AnsiConsole.Clear();
    }
}