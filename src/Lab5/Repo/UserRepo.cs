using Domain.DLA;
using Domain.DomainModels;
using Npgsql;

namespace Repo;

public class UserRepo : IUserRepo
{
    public UserRepo(NpgsqlConnection connectionBd)
    {
        ConnectionBd = connectionBd;
    }

    public NpgsqlConnection ConnectionBd { get; }
    public User? FindUserById(int id)
    {
        string findCommand = $"SELECT * FROM user_table WHERE id = {id}";
        using var command = new NpgsqlCommand(findCommand, ConnectionBd);
        using NpgsqlDataReader reader = command.ExecuteReader();
        if (!reader.Read())
        {
            return null;
        }

        return new User(reader.GetInt32(0), reader.GetString(1), Mapping.MapRole(reader.GetString(2)));
    }

    public void AddNewUser(int id, string password)
    {
        string addCommand = $"INSERT INTO user_table(id, password, role) VALUES({id}, '{password}', 'User')";
        using var command = new NpgsqlCommand(addCommand, ConnectionBd);
        command.ExecuteNonQuery();
    }
}