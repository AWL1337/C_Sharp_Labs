using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Recipients;
using Itmo.ObjectOrientedProgramming.Lab3.Service;
using Itmo.ObjectOrientedProgramming.Lab3.Service.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class UserAddressee : BaseAddressee
{
    private SignificanceLevel _level;
    public UserAddressee(User user)
        : base(user)
    {
        if (user is null)
        {
            throw new NullUserException();
        }

        _level = user.Level;
    }

    public override MessageStatus Send(Message message, string topicName)
    {
        if (message is null)
        {
            throw new NullMessageException();
        }

        if (Filter(message))
        {
            return SuccessSend(message, topicName);
        }

        AddToMessageLog(message, topicName);
        return MessageStatus.HasBeenRejected;
    }

    public override void AddToMessageLog(Message message, string topicName)
    {
        if (message is null)
        {
            throw new NullMessageException();
        }

        AddMessage(new LogMessage(topicName, Filter(message) ? MessageStatus.HasBeenSent : MessageStatus.HasBeenRejected));
    }

    public virtual MessageStatus SuccessSend(Message message, string topicName)
    {
        return base.Send(message, topicName);
    }

    private bool Filter(Message message)
    {
        return message.SignificanceLevel <= _level;
    }
}