using Domain.DomainModels;

namespace Domain.DLA;

public interface IBankAccountRepo
{
    public IEnumerable<BankAccount> FindBankAccountsByUserId(int userId);
    public BankAccount? FindBankAccountByAccountId(int id);

    public void AddNewBankAccount(int userId, int accountId);

    public void UpdateBankAccount(int accountId, int newValue);

    public IEnumerable<int> GetAllId();
}