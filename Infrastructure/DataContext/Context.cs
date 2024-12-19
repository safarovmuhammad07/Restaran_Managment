using System.Data;
using System.Data.Common;
using Npgsql;




namespace Infrastructure.DataContext;

public class Context
{
    readonly string connectionString = "Server=localhost; Port = 5432; Database = test; User Id = postgres; Password = 1234;";

    public NpgsqlConnection Connection()
    {
        return new NpgsqlConnection(connectionString);
    }
}
