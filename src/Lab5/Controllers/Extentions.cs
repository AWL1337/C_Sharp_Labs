using Controllers.ActionControllers;
using Controllers.RegisterControllers;
using Services;

namespace Controllers;

public static class Extentions
{
    public static BaseController SetUpControllers(UserServices userServices, AccountServices accountServices, ActionServices actionServices)
    {
        var start = new RegisterController();
        var registration = new RegistrationController(userServices);
        var login = new LoginController(userServices);
        var quit = new QuitController();

        start.AddAction(registration);
        start.AddAction(login);
        start.AddAction(quit);

        var actions = new ActionController();
        var changeBalance = new UpdateMoneyController(actionServices, accountServices);
        var addNewBankAccount = new AddNewBankAccountController(accountServices);
        var addNewUser = new AddNewUserController(userServices);
        var showBalance = new ShowAccountsBalanceController(accountServices);
        var showHistory = new ShowAccountHistoryController(actionServices);
        var exit = new LogOutController();

        actions.AddAction(changeBalance);
        actions.AddAction(addNewBankAccount);
        actions.AddAction(addNewUser);
        actions.AddAction(showBalance);
        actions.AddAction(showHistory);
        actions.AddAction(exit);

        start.SetNext(actions);

        return start;
    }
}