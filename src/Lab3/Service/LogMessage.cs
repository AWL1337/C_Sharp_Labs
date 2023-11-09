using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Service;

public class LogMessage
{
    public LogMessage(string messageName, MessageStatus messageStatus)
    {
        Time = DateTime.Now;
        MessageName = messageName;
        MessageStatus = messageStatus;
    }

    public LogMessage(string messageName)
    {
        Time = DateTime.Now;
        MessageName = messageName;
        MessageStatus = MessageStatus.HasBeenSent;
    }

    public LogMessage()
    {
        MessageName = string.Empty;
        MessageStatus = MessageStatus.HasBeenRejected;
    }

    public DateTime Time { get; }
    public string MessageName { get; }
    public MessageStatus MessageStatus { get; }
}