using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Recipients;
using Itmo.ObjectOrientedProgramming.Lab3.Service;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public abstract class BaseAddressee
{
    private readonly Collection<LogMessage> _logMessages;

    protected BaseAddressee(BaseRecipient display)
    {
        Recipient = display;
        _logMessages = new Collection<LogMessage>();
    }

    public BaseRecipient Recipient { get; }

    public virtual void AddToMessageLog(Message message, string topicName)
    {
        _logMessages.Add(new LogMessage(topicName));
    }

    public IEnumerable<LogMessage> ShowMessageLog()
    {
        return _logMessages;
    }

    public virtual MessageStatus Send(Message message, string topicName)
    {
        AddToMessageLog(message, topicName);
        Recipient.MessageGet(message, topicName);
        return MessageStatus.HasBeenSent;
    }

    protected void AddMessage(LogMessage message)
    {
        _logMessages.Add(message);
    }
}