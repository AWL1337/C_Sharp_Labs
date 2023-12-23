using System.Diagnostics.CodeAnalysis;
using Controllers.Requests;
using Controllers.Requests.RegisterRequests;
using Controllers.Results;
using Domain.Exceptions;
using Lab5.Controllers.Results;
using Services;

namespace Controllers.RegisterControllers;

public class LoginController : BaseController
{
    private new const string Name = "Log in";
    public LoginController(UserServices userServices)
        : base(Name)
    {
        UserServices = userServices;
    }

    public UserServices UserServices { get; }
    public override BaseOutput Run(BaseRequest request, [NotNull]State state)
    {
        if (request is not LoginRequest req) return new Pass();
        try
        {
            state.User = UserServices.Login(req.Id, req.Password);
            return new Success("You have successfully logged in");
        }
        catch (UserException exception)
        {
            return new Fail(exception.Message);
        }
    }
}