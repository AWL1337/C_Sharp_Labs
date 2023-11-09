using Itmo.ObjectOrientedProgramming.Lab3.Service;
using Itmo.ObjectOrientedProgramming.Lab3.Service.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;

public class MessageBuilder
{
    public MessageBuilder()
    {
        SignificanceLevel = SignificanceLevel.Low;
        Header = string.Empty;
        Body = string.Empty;
    }

    public MessageBuilder(Message message)
    {
        if (message is null)
        {
            throw new NullMessageException();
        }

        SignificanceLevel = message.SignificanceLevel;
        Header = message.Header;
        Body = message.Body;
    }

    public string Header { get; set; }
    public string Body { get; set; }
    public SignificanceLevel SignificanceLevel { get; set; }

    public Message Build()
    {
        return new Message(Header, Body, SignificanceLevel);
    }
}