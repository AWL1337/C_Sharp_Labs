namespace Domain.DomainModels;

public record Transaction(int Id, int AccountId, TransactionType Type, int Value);