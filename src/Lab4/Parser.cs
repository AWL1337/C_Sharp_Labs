using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Composite;
using Itmo.ObjectOrientedProgramming.Lab4.Composite.Builder;
using Itmo.ObjectOrientedProgramming.Lab4.Composite.Director;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class Parser
{
    private BaseCompositeNode _root;
    public Parser()
    {
        _root = new BaseCompositeNode();

        var parserBuilder = new CompositeBuilder(_root);
        var parserDirector = new ParserCompositeDirector();
        parserDirector.Direct(parserBuilder);
    }

    public ICommand ParseCommand([NotNull]string stringCommand)
    {
        var flags = new Dictionary<string, string>();
        var arguments = new Collection<string>();
        string[] tokens = SplitCommandString(stringCommand);

        ICommand? command = _root.Search(tokens);
        ParseArgumentsFlags(arguments, flags, tokens);

        switch (command)
        {
            case ICommandWithParamsFlags comm:
                comm.SetParams(arguments);
                comm.SetFlags(flags);
                return comm;
            case ICommandWithParams comm:
                comm.SetParams(arguments);
                return comm;
            case not null:
                return command;
            default:
                throw new NoCommandException();
        }
    }

    private static string[] SplitCommandString([NotNull]string stringCommand)
    {
        var substrings = new List<string>();
        string substring = string.Empty;
        bool quotesFlag = false;

        foreach (char symbol in stringCommand)
        {
            if (symbol == ' ' && !quotesFlag)
            {
                if (!string.IsNullOrEmpty(substring)) substrings.Add(substring);
                substring = string.Empty;
                continue;
            }

            if (symbol == '"')
            {
                quotesFlag = !quotesFlag;
                continue;
            }

            substring += symbol;
        }

        if (!string.IsNullOrEmpty(substring)) substrings.Add(substring);

        return substrings.ToArray();
    }

    private static void ParseArgumentsFlags(Collection<string> arguments, Dictionary<string, string> flags, string[] tokens)
    {
        string currentArg = string.Empty;
        foreach (string arg in tokens)
        {
            if (arg[0] == '-')
            {
                currentArg = arg.TrimStart('-');
                flags[currentArg] = string.Empty;
            }
            else
            {
                if (!string.IsNullOrEmpty(currentArg))
                {
                    flags[currentArg] = arg;
                    currentArg = string.Empty;
                }
                else
                {
                    arguments.Add(arg);
                }
            }
        }
    }
}