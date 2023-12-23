using Domain.DomainModels;

namespace Repo;

public static class Mapping
{
    public static UserRole MapRole(string role)
    {
        return role switch
        {
            "Admin" => UserRole.Admin,
            "User" => UserRole.User,
            _ => UserRole.User,
        };
    }

    public static TransactionType MapTypeTransaction(string type)
    {
        return type switch
        {
            "Replenishment" => TransactionType.Replenishment,
            "Withdraw" => TransactionType.Withdraw,
            _ => TransactionType.Replenishment,
        };
    }

    public static string MapString(TransactionType type)
    {
        return type switch
        {
            TransactionType.Replenishment => "Replenishment",
            TransactionType.Withdraw => "Withdraw",
            _ => "Withdraw",
        };
    }
}
