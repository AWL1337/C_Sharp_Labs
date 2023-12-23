using Npgsql;
using Repo;

NpgsqlConnection con = Extentions.SetUpProvider();
using var comm = new NpgsqlCommand();
comm.Connection = con;
comm.CommandText = Extentions.AddAdmin();
