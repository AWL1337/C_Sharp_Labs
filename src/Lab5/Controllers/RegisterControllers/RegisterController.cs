using System.Diagnostics.CodeAnalysis;
using Controllers.Requests;
using Controllers.Results;

namespace Controllers.RegisterControllers;

public class RegisterController : BaseController
{
    private new const string Name = "Create new bank account";
    public RegisterController()
        : base(Name)
    {
    }

    public override BaseOutput Run([NotNull]BaseRequest request, [NotNull]State state)
    {
        if (state.HasUser())
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

    public override IEnumerable<string> SeeActions([NotNull]State state)
    {
        if (Next is null) return new List<string>();
        if (state.HasUser()) return Next.SeeActions(state);
        return base.SeeActions(state);
    }
}