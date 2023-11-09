using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients;

public abstract class BaseRecipient
{
    public abstract void MessageGet(Message message, string topicName);
}