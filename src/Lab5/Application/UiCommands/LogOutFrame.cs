using Controllers.Requests;
using Controllers.Requests.ActionRequests;
using Controllers.Results;
using Spectre.Console;

namespace Application.UiCommands;

public class LogOutFrame : UiFrame
{
    public override BaseRequest Run()
    {
        return new LogOutRequest(AnsiConsole.Confirm("Do you want to log out?"));
    }

    public override void Response(BaseOutput output)
    {
        AnsiConsole.Clear();
    }
}