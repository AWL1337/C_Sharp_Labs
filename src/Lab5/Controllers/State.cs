using Domain.DomainModels;

namespace Controllers;

public class State
{
    public User? User { get; set; }

    public bool HasUser() => User is not null;
}