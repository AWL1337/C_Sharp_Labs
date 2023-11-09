using Itmo.ObjectOrientedProgramming.Lab3.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Service;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topic;

public class MessageTopic
{
    public MessageTopic(BaseAddressee addressee, string name)
    {
       Addressee = addressee;
       Name = name;
    }

    public BaseAddressee Addressee { get; }
    public string Name { get; }

    public MessageStatus Send(Message message)
    {
        return Addressee.Send(message, Name);
    }
}