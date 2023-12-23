using Controllers.Requests;
using Controllers.Results;
using Npgsql;
using Repo;
using Services;

namespace Controllers;

public class ControllersAccessPoint
{
    public ControllersAccessPoint()
    {
        NpgsqlConnection connect = Repo.Extentions.SetUpProvider();
        var accountserv = new AccountServices(new BankAccountRepo(connect));
        Start = Extentions.SetUpControllers(new UserServices(new UserRepo(connect)), accountserv, new ActionServices(accountserv, new HistoryRepo(connect)));
    }

    public State State { get; } = new State();
    public BaseController Start { get; }

    public IEnumerable<string> Options()
    {
        return Start.SeeActions(State);
    }

    public BaseOutput Run(BaseRequest request)
    {
        return Start.Run(request, State);
    }
}