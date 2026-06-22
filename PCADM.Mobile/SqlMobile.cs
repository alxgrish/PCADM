using MySqlConnector;
using System.Data;

namespace PCADM.Mobile;

public static class SqlMobile
{
    private static readonly MySqlConnectionStringBuilder ConnectionString = new()
    {
        Server = "localhost",
        Port = 3306,
        UserID = "root",
        Password = "",
        Database = "Answer_Book_problem",
        ConnectionTimeout = 5,
        CharacterSet = "utf8mb4"
    };

    public static DataTable? Query(string sql, MySqlParameter[]? parameters = null)
    {
        using var connection = new MySqlConnection(ConnectionString.ConnectionString);
        try
        {
            connection.Open();
            using var command = new MySqlCommand(sql, connection);
            if (parameters is not null)
                command.Parameters.AddRange(parameters);
            using var adapter = new MySqlDataAdapter(command);
            var dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        catch
        {
            return null;
        }
    }

    public static bool QueryNonReturns(string sql, MySqlParameter[]? parameters = null)
    {
        using var connection = new MySqlConnection(ConnectionString.ConnectionString);
        try
        {
            connection.Open();
            using var command = new MySqlCommand(sql, connection);
            if (parameters is not null)
                command.Parameters.AddRange(parameters);
            return command.ExecuteNonQuery() > 0;
        }
        catch
        {
            return false;
        }
    }
}
