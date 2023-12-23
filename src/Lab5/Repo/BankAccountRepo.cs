using Domain.DLA;
using Npgsql;

namespace Repo;

public class BankAccountRepo : IBankAccountRepo
{
    public BankAccountRepo(NpgsqlConnection connectionBd)
    {
        ConnectionBd = connectionBd;
    }

    public NpgsqlConnection ConnectionBd { get; }

    public IEnumerable<Domain.DomainModels.BankAccount> FindBankAccountsByUserId(int userId)
    {
        string findCommand = $"SELECT * FROM bankaccount WHERE userid = {userId}";
        using var command = new NpgsqlCommand(findCommand, ConnectionBd);
        using NpgsqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            yield return
                new Domain.DomainModels.BankAccount(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2));
        }
    }

    public Domain.DomainModels.BankAccount? FindBankAccountByAccountId(int id)
    {
        string findCommand = $"SELECT * FROM bankaccount WHERE id = {id}";
        using var command = new NpgsqlCommand(findCommand, ConnectionBd);
        using NpgsqlDataReader reader = command.ExecuteReader();

        if (reader.Read())
        {
            return new Domain.DomainModels.BankAccount(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2));
        }

        return null;
    }

    public void AddNewBankAccount(int userId, int accountId)
    {
        string addCommand = $"INSERT INTO bankaccount(id, userid, money) VALUES({accountId}, {userId}, 0)";
        using var command = new NpgsqlCommand(addCommand, ConnectionBd);
        command.ExecuteNonQuery();
    }

    public void UpdateBankAccount(int accountId, int newValue)
    {
        string addCommand = $"UPDATE bankaccount SET money = {newValue} WHERE id = {accountId}";
        using var command = new NpgsqlCommand(addCommand, ConnectionBd);
        command.ExecuteNonQuery();
    }

    public IEnumerable<int> GetAllId()
    {
        string findCommand = $"SELECT id FROM bankaccount";
        using var command = new NpgsqlCommand(findCommand, ConnectionBd);
        using NpgsqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            yield return reader.GetInt32(0);
        }
    }
}