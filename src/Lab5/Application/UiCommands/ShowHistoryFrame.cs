using Controllers.Requests;
using Controllers.Requests.ActionRequests;
using Controllers.Results;
using Domain.DomainModels;
using Spectre.Console;

namespace Application.UiCommands;

public class ShowHistoryFrame : UiFrame
{
    public override BaseRequest Run()
    {
        int id = AnsiConsole.Ask<int>("AccountId: ");
        return new ShowHistoryRequest(id);
    }

    public override void Response(BaseOutput output)
    {
        if (output is not HistoryList res)
        {
            base.Response(output);
            return;
        }

        Table table = new Table().Centered();
        AnsiConsole.Live(table)
            .Start(obj =>
            {
                table.AddColumn("Id");
                obj.Refresh();
                Thread.Sleep(1000);

                table.AddColumn("AccountId");
                obj.Refresh();
                Thread.Sleep(1000);

                table.AddColumn("Type");
                obj.Refresh();
                Thread.Sleep(1000);

                table.AddColumn("Value");
                obj.Refresh();
                Thread.Sleep(1000);

                foreach (Transaction transaction in res.Transactions)
                {
                    table.AddRow($"{transaction.Id}", $"{transaction.AccountId}", $"{transaction.Type}", $"{transaction.Value}");
                    obj.Refresh();
                    Thread.Sleep(500);
                }
            });
        Thread.Sleep(2000);
    }
}