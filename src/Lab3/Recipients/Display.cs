using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Drivers;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients;

public class Display : BaseRecipient
{
    public Display(BaseDisplayDriver driver)
    {
        Driver = driver;
    }

    public BaseDisplayDriver Driver { get; }

    public override void MessageGet(Message message, string topicName)
    {
        Driver.Out(message);
    }

    public void SetColor(Color color)
    {
        Driver.SetColor(color);
    }
}