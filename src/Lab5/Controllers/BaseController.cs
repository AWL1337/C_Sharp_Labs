using System.Collections.ObjectModel;
using Controllers.Requests;
using Controllers.Results;

namespace Controllers;

public abstract class BaseController
{
    protected BaseController(string name)
    {
        Name = name;
    }

    public Collection<BaseController> Actions { get; } = new Collection<BaseController>();
    public BaseController? Next { get; private set; }
    public string Name { get; }

    public void SetNext(BaseController controller)
    {
        Next = controller;
    }

    public void AddAction(BaseController controller)
    {
        Actions.Add(controller);
    }

    public virtual BaseOutput Run(BaseRequest request, State state)
    {
        if (Next is null) return new NoNext();
        return Next.Run(request, state);
    }

    public virtual IEnumerable<string> SeeActions(State state)
    {
        return Actions.Select(action => action.Name);
    }
}