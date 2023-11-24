using System;
using System.Globalization;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.State;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class Application
{
    public Application()
    {
        State = new SystemState();
        Parser = new Parser();
    }

    public SystemState State { get; }
    public Parser Parser { get; }

    public void Start()
    {
        while (true)
        {
            string? stringCommand = Console.ReadLine();

            if (stringCommand is null) continue;

            ICommand command = Parser.ParseCommand(stringCommand.ToLower(CultureInfo.CurrentCulture));

            if (command is not Connect && !State.IsInitiated()) throw new ApplicationConnectionException();

            command.GiveState(State);
            command.Execute();

            if (command is Disconnect) break;
        }
    }
}