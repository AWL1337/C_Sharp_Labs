using Npgsql;

namespace Repo;

public static class Extentions
{
    private const string ConnectionString = "Host=localhost;" +
                                            "Port=6432;" +
                                            "Database=ball;" +
                                             "Username=lol;" +
                                             "Password=kek";
    public static NpgsqlConnection SetUpProvider()
    {
        var connection = new NpgsqlConnection(ConnectionString);
        connection.Open();
        return connection;
    }

    public static string StartDB() => """
                                      CREATE TABLE user_table(id integer PRIMARY KEY, password text, role text);
                                      CREATE TABLE bankaccount(id integer PRIMARY KEY, userid integer, money integer);
                                      CREATE TABLE history(id integer PRIMARY KEY, accountid integer, type text, value integer);
                                      """;
    public static string StopDB() => """
                                      DROP TABLE user_table;
                                      DROP TABLE bankaccount;
                                      DROP TABLE history;
                                      """;

    public static string AddAdmin() => "INSERT INTO user_table(id, password, role) VALUES(228, '228', 'Admin')";
}