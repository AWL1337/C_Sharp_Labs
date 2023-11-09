using Itmo.ObjectOrientedProgramming.Lab3.Service;
using Itmo.ObjectOrientedProgramming.Lab3.Service.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;

public class UserMessage : Message
{
    public UserMessage()
    {
        Name = string.Empty;
    }

    public UserMessage(Message message, string topicName)
        : base(message)
    {
        Name = topicName;
    }

    public string Name { get; }
    public Mark Mark { get; private set; }

    public void MarkedRead()
    {
        if (Mark == Mark.Read)
        {
            throw new MarkReadReadMessageException();
        }

        Mark = Mark.Read;
    }

    public void SetCustomMark(Mark mark)
    {
        Mark = mark;
    }
}