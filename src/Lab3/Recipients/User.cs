using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Service;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients;

public class User : BaseRecipient
{
    private readonly Collection<UserMessage> _userLog;
    public User(SignificanceLevel level)
    {
        Level = level;
        _userLog = new Collection<UserMessage>();
    }

    public SignificanceLevel Level { get; }

    public void MarkRead(string name)
    {
        _userLog.First(obj => obj.Name == name).MarkedRead();
    }

    public void MarkCustom(string name, Mark mark)
    {
        _userLog.First(obj => obj.Name == name).SetCustomMark(mark);
    }

    public IEnumerable<UserMessage> ShowMessages()
    {
        return _userLog;
    }

    public override void MessageGet(Message message, string topicName)
    {
        _userLog.Add(new UserMessage(message, topicName));
    }
}