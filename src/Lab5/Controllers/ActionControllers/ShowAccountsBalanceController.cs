using Controllers.Requests;
using Controllers.Requests.ActionRequests;
using Controllers.Results;
using Domain.DomainModels;
using Domain.Exceptions;
using Lab5.Controllers.Results;
using Services;

namespace Controllers.ActionControllers;

public class ShowAccountsBalanceController : BaseController
{
    private new const string Name = "Show balance";
    public ShowAccountsBalanceController(AccountServices accountServices)
        : base(Name)
    {
        AccountServices = accountServices;
    }

    public AccountServices AccountServices { get; }
    public override BaseOutput Run(BaseRequest request, State state)
    {
        if (request is not ShowBalanceRequest req) return new Pass();
        try
        {
            if (state.User is null) return new Fail("No user");
            IEnumerable<BankAccount> accs = AccountServices.FindBankAccountsByUserId(state.User, req.Id);
            return new AccountList(accs);
        }
        catch (AccessException exception)
        {
            return new Fail(exception.Message);
        }
    }
}