using System.Diagnostics.CodeAnalysis;
using Domain.DLA;
using Domain.DomainModels;
using Domain.Exceptions;

namespace Services;

public class ActionServices
{
    private AccountServices _accountServices;
    private IHistoryRepo _historyRepo;

    public ActionServices(AccountServices accountServices, IHistoryRepo historyServices)
    {
        _accountServices = accountServices;
        _historyRepo = historyServices;
    }

    public IEnumerable<Transaction> ShowTransactionsByAccountId([NotNull]User user, int accountId)
    {
        IEnumerable<BankAccount> accs = _accountServices.FindBankAccountsByUserId(user, user.Id);
        if (accs.All(obj => obj.Id != accountId) && user.Role != UserRole.Admin)
        {
            throw new AccessException("You have no permission to look this account history");
        }

        return _historyRepo.ShowTransactionsByAccountId(accountId);
    }

    public void UpdateBankAccount([NotNull]User user, int accountId, int newValue)
    {
        if (newValue < 0)
        {
            throw new OperationException("You cannot to take too much money");
        }

        IEnumerable<BankAccount> accs = _accountServices.FindBankAccountsByUserId(user, user.Id);
        if (accs.All(obj => obj.Id != accountId) && user.Role != UserRole.Admin)
        {
            throw new OperationException("You have no permission to change this account");
        }

        BankAccount acc = _accountServices.FindBankAccountsByAccountId(accountId);
        int newId = GetNewId.NewId(_historyRepo.GetAllId());
        Transaction transaction = (newValue - acc.Money) switch
        {
            > 0 => new Transaction(newId, accountId, TransactionType.Replenishment, int.Abs(newValue - acc.Money)),
            < 0 => new Transaction(newId, accountId, TransactionType.Withdraw, int.Abs(newValue - acc.Money)),
            _ => throw new OperationException("Useless operation"),
        };
        _accountServices.UpdateBankAccount(accountId, newValue);
        _historyRepo.AddTransaction(transaction);
    }
}