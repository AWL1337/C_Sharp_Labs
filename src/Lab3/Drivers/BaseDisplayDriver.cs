using System;
using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Service.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab3.Drivers;

public abstract class BaseDisplayDriver
{
    public Color Color { get; private set; }
    public virtual void Out(Message message)
    {
        if (message is null)
        {
            throw new NullMessageException();
        }

        Console.WriteLine("Display: " + message.Header + '\t' + message.Body + '\n' + "Color: " + "R= " + Color.R + ' ' + "G= " + Color.G + ' ' + "B= " + Color.B + ' ');
    }

    public virtual void SetColor(Color color)
    {
        Color = color;
    }

    public virtual void Clear()
    {
        Console.Clear();
    }
}