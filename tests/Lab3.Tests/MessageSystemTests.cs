using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Recipients;
using Itmo.ObjectOrientedProgramming.Lab3.Service;
using Itmo.ObjectOrientedProgramming.Lab3.Service.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Topic;
using NSubstitute;
using Xunit;
namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class MessageSystemTests
{
    [Fact]
    public void NonReadMessageTest()
    {
        const int expectedLen = 1;
        const string testString = "test";
        var user = new User(SignificanceLevel.Low);
        var message = new Message(testString, testString, SignificanceLevel.SuperPuperMegaGigaHigh);

        user.MessageGet(message, testString);
        int result = user.ShowMessages().Count();

        Assert.Equal(expectedLen, result);
    }

    [Fact]
    public void ReadMessageMarkReadTest()
    {
        const Mark expectedMark = Mark.Read;
        const string testString = "test";
        var user = new User(SignificanceLevel.Low);
        var message = new Message(testString, testString, SignificanceLevel.SuperPuperMegaGigaHigh);

        user.MessageGet(message, testString);
        user.MarkRead(testString);
        Mark result = user.ShowMessages().First().Mark;

        Assert.Equal(expectedMark, result);
    }

    [Fact]
    public void ReadMessageMarkReadReadTest()
    {
        const string testString = "test";
        var user = new User(SignificanceLevel.Low);
        var message = new Message(testString, testString, SignificanceLevel.SuperPuperMegaGigaHigh);

        user.MessageGet(message, testString);
        user.MarkRead(testString);

        Assert.Throws<MarkReadReadMessageException>(() => user.MarkRead(testString));
    }

    [Fact]
    public void FilterTest()
    {
        const string testString = "test";
        var user = new User(SignificanceLevel.Low);
        UserAddressee mock = Substitute.ForPartsOf<UserAddressee>(user);
        var message = new Message(testString, testString, SignificanceLevel.SuperPuperMegaGigaHigh);
        var topic = new MessageTopic(mock, testString);

        topic.Send(message);

        mock.DidNotReceive().SuccessSend(message, testString);
    }

    [Fact]
    public void LogTest()
    {
        const string testString = "test";
        var user = new User(SignificanceLevel.Low);
        UserAddressee mock = Substitute.ForPartsOf<UserAddressee>(user);
        var message = new Message(testString, testString, SignificanceLevel.SuperPuperMegaGigaHigh);
        var topic = new MessageTopic(mock, testString);

        topic.Send(message);

        mock.Received().AddToMessageLog(message, testString);
    }

    [Fact]
    public void MessangerTest()
    {
        const string testString = "test";
        const string expectedString = "Messanger: " + testString + " " + testString + " " + testString;
        Messanger mock = Substitute.ForPartsOf<Messanger>();
        var message = new Message(testString, testString, SignificanceLevel.SuperPuperMegaGigaHigh);

        string result = mock.ConcatenateMessage(message, testString);

        Assert.Equal(expectedString, result);
        mock.Received().ConcatenateMessage(message, testString);
    }
}