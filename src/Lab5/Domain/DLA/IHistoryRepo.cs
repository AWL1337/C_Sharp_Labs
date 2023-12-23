using Domain.DomainModels;

namespace Domain.DLA;

public interface IHistoryRepo
{
    public void AddTransaction(Transaction transaction);

    public IEnumerable<Transaction> ShowTransactionsByAccountId(int accountId);

    public IEnumerable<int> GetAllId();
}