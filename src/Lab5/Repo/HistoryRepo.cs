using Domain.DLA;
using Domain.DomainModels;
using Npgsql;

namespace Repo;

public class HistoryRepo : IHistoryRepo
{
    public HistoryRepo(NpgsqlConnection connectionBd)
    {
        ConnectionBd = connectionBd;
    }

    public NpgsqlConnection ConnectionBd { get; }
    public void AddTransaction(Transaction transaction)
    {
        string addCommand = $"INSERT INTO history(id, accountid, type, value) VALUES({transaction.Id}, {transaction.AccountId}, '{Mapping.MapString(transaction.Type)}', {transaction.Value})";
        using var command = new NpgsqlCommand(addCommand, ConnectionBd);
        command.ExecuteNonQuery();
    }

    public IEnumerable<Transaction> ShowTransactionsByAccountId(int accountId)
    {
        string findCommand = $"SELECT * FROM history WHERE accountid = {accountId}";
        using var command = new NpgsqlCommand(findCommand, ConnectionBd);
        using NpgsqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            yield return new Transaction(reader.GetInt32(0), reader.GetInt32(1), Mapping.MapTypeTransaction(reader.GetString(2)), reader.GetInt32(3));
        }
    }

    public IEnumerable<int> GetAllId()
    {
        string findCommand = $"SELECT id FROM history";
        using var command = new NpgsqlCommand(findCommand, ConnectionBd);
        using NpgsqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            yield return reader.GetInt32(0);
        }
    }
}