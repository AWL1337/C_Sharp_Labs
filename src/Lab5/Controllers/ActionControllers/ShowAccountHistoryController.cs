using Controllers.Requests;
using Controllers.Requests.ActionRequests;
using Controllers.Results;
using Domain.DomainModels;
using Domain.Exceptions;
using Lab5.Controllers.Results;
using Services;

namespace Controllers.ActionControllers;

public class ShowAccountHistoryController : BaseController
{
    private new const string Name = "Show history";
    public ShowAccountHistoryController(ActionServices actionServices)
        : base(Name)
    {
        ActionServices = actionServices;
    }

    public ActionServices ActionServices { get; }
    public override BaseOutput Run(BaseRequest request, State state)
    {
        if (request is not ShowHistoryRequest req) return new Pass();
        try
        {
            if (state.User is null) return new Fail("No user");
            IEnumerable<Transaction> history = ActionServices.ShowTransactionsByAccountId(state.User, req.Id);
            return new HistoryList(history);
        }
        catch (AccessException exception)
        {
            return new Fail(exception.Message);
        }
    }
}