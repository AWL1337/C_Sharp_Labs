using Controllers.Requests;
using Controllers.Requests.ActionRequests;
using Spectre.Console;

namespace Application.UiCommands;

public class NewBankAccountFrame : UiFrame
{
    public override BaseRequest Run()
    {
        int id = AnsiConsole.Ask<int>("UserId: ");
        return new CreateBankAccountRequest(id);
    }
}