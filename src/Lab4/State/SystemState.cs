using Itmo.ObjectOrientedProgramming.Lab4.Receivers;

namespace Itmo.ObjectOrientedProgramming.Lab4.State;

public class SystemState
{
    public string Head { get; set; } = string.Empty;
    public IReceiver Receiver { get; set; } = new NoReceiver();

    public bool IsInitiated()
    {
        return !string.IsNullOrEmpty(Head) && Receiver is not NoReceiver;
    }
}