using Controllers.Requests;
using Controllers.Requests.ActionRequests;
using Spectre.Console;

namespace Application.UiCommands;

public class CreateUserFrame : UiFrame
{
    public override BaseRequest Run()
    {
        int id = AnsiConsole.Ask<int>("New user id: ");
        string password = AnsiConsole.Ask<string>("New user password: ");
        return new CreateNewUserRequest(id, password);
    }
}