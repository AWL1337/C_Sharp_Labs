using Controllers.Requests;
using Controllers.Requests.RegisterRequests;
using Spectre.Console;

namespace Application.UiCommands;

public class RegistrationFrame : UiFrame
{
    public override BaseRequest Run()
    {
        int id = AnsiConsole.Ask<int>("Id: ");
        string password = AnsiConsole.Ask<string>("Password: ");
        return new RegistrationRequest(id, password);
    }
}