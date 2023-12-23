using Controllers.Requests;
using Controllers.Requests.ActionRequests;
using Spectre.Console;

namespace Application.UiCommands;

public class UpdateAccountFrame : UiFrame
{
    public override BaseRequest Run()
    {
        IEnumerable<string> ops = new List<string>() { "Take", "Put" };
        int id = AnsiConsole.Ask<int>("AccountId: ");
        string operation = AnsiConsole.Prompt(new SelectionPrompt<string>().Title("Choose Option").PageSize(5).AddChoices(ops));
        int diff = AnsiConsole.Ask<int>("Diff: ");

        switch (operation)
        {
            case "Take":
                diff = -diff;
                break;
            case "Put":
                break;
        }

        return new UpdateMoneyRequest(id, diff);
    }
}