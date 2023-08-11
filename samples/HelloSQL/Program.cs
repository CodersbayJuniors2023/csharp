using MySqlConnector;

namespace HelloSql;

class HelloSql
{
    private static async Task Main()
    {
        var builder = new MySqlConnectionStringBuilder
        {
            Server = "localhost",
            Database = "nation",
            UserID = "cb_user",
            Password = "codersbayuser",
            SslMode = MySqlSslMode.Disabled
        };
        
        // database connection
        await using (var conn = new MySqlConnection(builder.ConnectionString))
        {
            Console.WriteLine("Opening Connection");
            await conn.OpenAsync();
            
            await GetVips(conn);
            
            // TODO: implement some other get method
            
            Console.WriteLine("Closing Connection");
        }
        
        Console.WriteLine("Press RETURN to exit");
        Console.ReadLine();
    }

    private static async Task GetVips(MySqlConnection conn)
    {
        // create database statement
        await using (var command = conn.CreateCommand())
        {
            command.CommandText = "SELECT * FROM vips;";

            // execute statement in database
            await using (var reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    Console.WriteLine($"Reading from table=({reader.GetInt32(0)}, {reader.GetString(1)})");
                }
            }
        }
    }
}