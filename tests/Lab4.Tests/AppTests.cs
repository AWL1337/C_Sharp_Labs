using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class AppTests
{
    [Fact]
    public void ParserFileTest()
    {
        var parser = new Parser();
        string stringCommand = "file move a b";

        ICommand res = parser.ParseCommand(stringCommand);
        Assert.True(res is FileMove);
    }

    [Fact]
    public void ParserFileTestException()
    {
        var parser = new Parser();
        string stringCommand = "file move a";

        Assert.Throws<CommandArgumentException>(() => parser.ParseCommand(stringCommand));
    }

    [Fact]
    public void ParserNoCommandTestException()
    {
        var parser = new Parser();
        string stringCommand = "file1 move a";

        Assert.Throws<NoCommandException>(() => parser.ParseCommand(stringCommand));
    }

    [Fact]
    public void ParserDisconnectTest()
    {
        var parser = new Parser();
        string stringCommand = "disconnect ";

        ICommand res = parser.ParseCommand(stringCommand);

        Assert.True(res is Disconnect);
    }

    [Fact]
    public void ParserSpacePathTest()
    {
        var parser = new Parser();
        string stringCommand = "file move \"a b\" b";

        ICommand res = parser.ParseCommand(stringCommand);

        Assert.True(res is FileMove);
    }

    [Fact]
    public void ParserSpacePathTestException()
    {
        var parser = new Parser();
        string stringCommand = "file move a b b";

        Assert.Throws<CommandArgumentException>(() => parser.ParseCommand(stringCommand));
    }
}