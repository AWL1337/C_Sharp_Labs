using System.Diagnostics.CodeAnalysis;
using Controllers.Requests;
using Controllers.Requests.ActionRequests;
using Controllers.Results;
using Domain.Exceptions;
using Lab5.Controllers.Results;
using Services;

namespace Controllers.ActionControllers;

public class AddNewBankAccountController : BaseController
{
    private new const string Name = "Create new bank account";
    public AddNewBankAccountController(AccountServices accountServices)
        : base(Name)
    {
        AccountServices = accountServices;
    }

    public AccountServices AccountServices { get; }

    public override BaseOutput Run(BaseRequest request, [NotNull]State state)
    {
        if (request is not CreateBankAccountRequest req) return new Pass();
        try
        {
            if (state.User is null) return new Fail("No user");
            AccountServices.CreateBankAccount(state.User, req.Id);
            return new Success("You have created a new bank account");
        }
        catch (AccessException exception)
        {
            return new Fail(exception.Message);
        }
    }
}