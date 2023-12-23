using System.Diagnostics.CodeAnalysis;
using Controllers.Requests;
using Controllers.Requests.ActionRequests;
using Controllers.Results;
using Domain.Exceptions;
using Lab5.Controllers.Results;
using Services;

namespace Controllers.ActionControllers;

public class AddNewUserController : BaseController
{
    private new const string Name = "Create new user";
    public AddNewUserController(UserServices userServices)
        : base(Name)
    {
        UserServices = userServices;
    }

    public UserServices UserServices { get; }

    public override BaseOutput Run(BaseRequest request, [NotNull]State state)
    {
        if (request is not CreateNewUserRequest req) return new Pass();
        try
        {
            if (state.User is null) return new Fail("No user");
            UserServices.AddNewUser(state.User, req.Id, req.Password);
            return new Success("You have added a new user");
        }
        catch (UserException exception)
        {
            return new Fail(exception.Message);
        }
    }
}