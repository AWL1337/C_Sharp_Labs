using Controllers.Requests;
using Controllers.Requests.ActionRequests;
using Controllers.Results;
using Domain.DomainModels;
using Domain.Exceptions;
using Lab5.Controllers.Results;
using Services;

namespace Controllers.ActionControllers;

public class UpdateMoneyController : BaseController
{
    private new const string Name = "Update balance";
    public UpdateMoneyController(ActionServices actionServices, AccountServices accountServices)
        : base(Name)
    {
        ActionServices = actionServices;
        AccountServices = accountServices;
    }

    public ActionServices ActionServices { get; }
    public AccountServices AccountServices { get; }
    public override BaseOutput Run(BaseRequest request, State state)
    {
        if (request is not UpdateMoneyRequest req) return new Pass();
        try
        {
            if (state.User is null) return new Fail("No user");
            BankAccount acc = AccountServices.FindBankAccountsByAccountId(req.Id);
            ActionServices.UpdateBankAccount(state.User, req.Id, acc.Money + req.Diff);
            return new Success("Account has successfully updated");
        }
        catch (OperationException exception)
        {
            return new Fail(exception.Message);
        }
    }
}