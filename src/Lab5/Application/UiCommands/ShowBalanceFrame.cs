using Controllers.Requests;
using Controllers.Requests.ActionRequests;
using Controllers.Results;
using Domain.DomainModels;
using Spectre.Console;

namespace Application.UiCommands;

public class ShowBalanceFrame : UiFrame
{
    public override BaseRequest Run()
    {
        int id = AnsiConsole.Ask<int>("UserId: ");
        return new ShowBalanceRequest(id);
    }

    public override void Response(BaseOutput output)
    {
        if (output is not AccountList res)
        {
            base.Response(output);
            return;
        }

        Table table = new Table().Centered();
        AnsiConsole.Live(table)
            .Start(obj =>
            {
                table.AddColumn("AccountId");
                obj.Refresh();
                Thread.Sleep(1000);

                table.AddColumn("UserId");
                obj.Refresh();
                Thread.Sleep(1000);

                table.AddColumn("Money");
                obj.Refresh();
                Thread.Sleep(1000);

                foreach (BankAccount account in res.BankAccounts)
                {
                    table.AddRow($"{account.Id}", $"{account.UserId}", $"{account.Money}");
                    obj.Refresh();
                    Thread.Sleep(500);
                }
            });
        Thread.Sleep(2000);
    }
}