using Domain.DomainModels;

namespace Controllers.Results;

public record HistoryList(IEnumerable<Transaction> Transactions) : BaseOutput;