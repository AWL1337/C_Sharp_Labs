using Controllers.Requests;
using Controllers.Requests.RegisterRequests;
using Spectre.Console;

namespace Application.UiCommands;

public class LoginFrame : UiFrame
{
    public override BaseRequest Run()
    {
        int id = AnsiConsole.Ask<int>("Id: ");
        string password = AnsiConsole.Prompt(new TextPrompt<string>("Password: ").PromptStyle("red").Secret());
        return new LoginRequest(id, password);
    }
}