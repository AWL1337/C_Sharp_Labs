using System;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Service.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients;

public class Messanger : BaseRecipient
{
    public virtual string ConcatenateMessage(Message message, string topicName)
    {
        if (message is null)
        {
            throw new NullMessageException();
        }

        return new("Messanger: " + topicName + " " + message.Header + " " + message.Body);
    }

    public override void MessageGet(Message message, string topicName)
    {
        if (message is null)
        {
            throw new NullMessageException();
        }

        Console.WriteLine(ConcatenateMessage(message, topicName));
    }
}