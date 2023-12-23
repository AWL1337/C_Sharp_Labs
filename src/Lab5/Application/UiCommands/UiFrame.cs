using Controllers.Requests;
using Controllers.Results;
using Lab5.Controllers.Results;
using Spectre.Console;

namespace Application.UiCommands;

public abstract class UiFrame
{
    public abstract BaseRequest Run();

    public virtual void Response(BaseOutput output)
    {
        switch (output)
        {
            case Success res:
                AnsiConsole.WriteLine(res.Message);
                break;
            case Fail res:
                AnsiConsole.WriteLine(res.Message);
                break;
        }

        Thread.Sleep(2000);
        AnsiConsole.Clear();
    }
}