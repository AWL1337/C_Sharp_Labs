using Application.UiCommands;

namespace Application;

public static class Mapping
{
    public static UiFrame MapFrame(string name)
    {
        return name switch
        {
            "Log in" => new LoginFrame(),
           "Sign up" => new RegistrationFrame(),
           "Log out" => new LogOutFrame(),
            "Quit" => new QuitFrame(),
            "Create new bank account" => new NewBankAccountFrame(),
            "Show balance" => new ShowBalanceFrame(),
            "Show history" => new ShowHistoryFrame(),
            "Update balance" => new UpdateAccountFrame(),
            "Create new user" => new CreateUserFrame(),
            _ => new LoginFrame(),
        };
    }
}