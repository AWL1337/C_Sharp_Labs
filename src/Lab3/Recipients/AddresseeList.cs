using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab3.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Service.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients;

public class AddresseeList : BaseRecipient
{
    private readonly IEnumerable<BaseAddressee> _addressees;

    public AddresseeList(Collection<BaseAddressee> addressees)
    {
        _addressees = addressees;
    }

    public AddresseeList()
    {
        _addressees = new Collection<BaseAddressee>();
    }

    public override void MessageGet(Message message, string topicName)
    {
        if (message is null)
        {
            throw new NullMessageException();
        }

        foreach (BaseAddressee variableAddressee in _addressees)
        {
            variableAddressee.Send(message, topicName);
        }
    }
}