using Domain.DomainModels;

namespace Controllers.Results;

public record AccountList(IEnumerable<BankAccount> BankAccounts) : BaseOutput;