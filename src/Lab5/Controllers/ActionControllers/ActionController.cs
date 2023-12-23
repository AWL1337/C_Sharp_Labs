using Controllers.Requests;
using Controllers.Requests.ActionRequests;
using Controllers.Results;

namespace Controllers.ActionControllers;

public class ActionController : BaseController
{
    private new const string Name = "Action";
    public ActionController()
        : base(Name)
    {
    }

    public override BaseOutput Run(BaseRequest request, State state)
    {
        if (request is not ActionRequest)
        {
            return base.Run(request, state);
        }

        foreach (BaseController action in Actions)
        {
            BaseOutput output = action.Run(request, state);
            if (output is not Pass) return output;
        }

        return new NoNext();
    }
}