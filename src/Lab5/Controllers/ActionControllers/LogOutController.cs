using Controllers.Requests;
using Controllers.Requests.ActionRequests;
using Controllers.Results;
using Lab5.Controllers.Results;

namespace Controllers.ActionControllers;

public class LogOutController : BaseController
{
    private new const string Name = "Log out";
    public LogOutController()
        : base(Name)
    {
    }

    public override BaseOutput Run(BaseRequest request, State state)
    {
        if (request is not LogOutRequest req) return new Pass();
        if (state.User is null) return new Fail("No user");
        if (req.Agree) state.User = null;

        return new Success(string.Empty);
    }
}