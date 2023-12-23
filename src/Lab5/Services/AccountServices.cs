using System.Diagnostics.CodeAnalysis;
using Domain.DLA;
using Domain.DomainModels;
using Domain.Exceptions;

namespace Services;

public class AccountServices
{
    private IBankAccountRepo _bankAccountRepo;

    public AccountServices(IBankAccountRepo bankAccountRepo)
    {
        _bankAccountRepo = bankAccountRepo;
    }

    public void CreateBankAccount([NotNull]User user, int id)
    {
        if (user.Id != id && user.Role != UserRole.Admin)
        {
            throw new AccessException("You have no permission to create not yours account");
        }

        int newId = GetNewId.NewId(_bankAccountRepo.GetAllId());
        _bankAccountRepo.AddNewBankAccount(id, newId);
    }

    public IEnumerable<BankAccount> FindBankAccountsByUserId([NotNull]User user, int id)
    {
        if (user.Id != id && user.Role != UserRole.Admin)
        {
            throw new AccessException("You have no permission to look not yours accounts");
        }

        return _bankAccountRepo.FindBankAccountsByUserId(id);
    }

    public BankAccount FindBankAccountsByAccountId(int id)
    {
        BankAccount? acc = _bankAccountRepo.FindBankAccountByAccountId(id);
        if (acc is null) throw new OperationException("There is no such bankAccount");
        return acc;
    }

    public void UpdateBankAccount(int accountId, int newValue)
    {
        _bankAccountRepo.UpdateBankAccount(accountId, newValue);
    }
}