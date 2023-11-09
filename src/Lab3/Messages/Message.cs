using Itmo.ObjectOrientedProgramming.Lab3.Service;
using Itmo.ObjectOrientedProgramming.Lab3.Service.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;

public class Message
{
    public Message(string header, string body, SignificanceLevel level)
    {
        Header = header;
        Body = body;
        SignificanceLevel = level;
    }

    public Message(Message message)
    {
        if (message is null)
        {
            throw new NullMessageException();
        }

        Header = message.Header;
        Body = message.Body;
        SignificanceLevel = message.SignificanceLevel;
    }

    public Message()
    {
        SignificanceLevel = SignificanceLevel.Low;
        Header = string.Empty;
        Body = string.Empty;
    }

    public string Header { get; }
    public string Body { get; }
    public SignificanceLevel SignificanceLevel { get; }

    public MessageBuilder DeBuild()
    {
        return new MessageBuilder(this);
    }
}