using System.Diagnostics.CodeAnalysis;
using Controllers.Requests;
using Controllers.Requests.RegisterRequests;
using Controllers.Results;
using Domain.Exceptions;
using Lab5.Controllers.Results;
using Services;

namespace Controllers.RegisterControllers;

public class RegistrationController : BaseController
{
    private new const string Name = "Sign up";
    public RegistrationController(UserServices userServices)
        : base(Name)
    {
        UserServices = userServices;
    }

    public UserServices UserServices { get; }
    public override BaseOutput Run(BaseRequest request, [NotNull]State state)
    {
        if (request is not RegistrationRequest req) return new Pass();
        try
        {
            UserServices.AddNewUser(state.User, req.Id, req.Password);
            return new Success("You have successfully registered");
        }
        catch (UserException exception)
        {
            return new Fail(exception.Message);
        }
    }
}