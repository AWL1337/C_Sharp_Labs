using Controllers.Requests;
using Controllers.Requests.RegisterRequests;
using Controllers.Results;

namespace Controllers.RegisterControllers;

public class QuitController : BaseController
{
    private new const string Name = "Quit";
    public QuitController()
        : base(Name)
    {
    }

    public override BaseOutput Run(BaseRequest request, State state)
    {
        if (request is not QuitRequest req) return new Pass();
        if (req.Agree) Environment.Exit(0);
        return new Success(string.Empty);
    }
}