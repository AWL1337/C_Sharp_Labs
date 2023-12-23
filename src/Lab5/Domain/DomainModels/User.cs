namespace Domain.DomainModels;

public record User(int Id, string Password, UserRole Role);