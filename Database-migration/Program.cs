using Npgsql;
using System.Collections.Generic;
using System.Data.SqlClient;

class Program
{
    static async Task Main(string[] args)
    {
        //Add connection strings
        var msSqlConnectionString = ""; // Microsoft SQL Server
        var psqlConnectionString = ""; //Postgres SQL

        //Add table names which you want to migrate
        var tables = new[] { "tables" };

        foreach (var table in tables)
        {
            var data = await QueryMsSqlTableAsync(msSqlConnectionString, table);
            await InsertDataToPsqlTableAsync(psqlConnectionString, table, data);

            Console.WriteLine($"Data transfer completed , Table : {table}.");
        }
        Console.WriteLine("Data transfer completed.");
    }

    static async Task<List<Dictionary<string, object>>> QueryMsSqlTableAsync(string connectionString, string tableName)
    {
        var result = new List<Dictionary<string, object>>();

        using (var connection = new SqlConnection(connectionString))
        {
            await connection.OpenAsync();

            var sql = $"SELECT * FROM {tableName}";

            using (var command = new SqlCommand(sql, connection))
            using (var reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    var row = new Dictionary<string, object>();

                    for (var i = 0; i < reader.FieldCount; i++)
                    {
                        var value = reader.GetValue(i);
                        row[reader.GetName(i)] = value;
                    }

                    result.Add(row);
                }
            }
        }

        return result;
    }

    static async Task InsertDataToPsqlTableAsync(string connectionString, string tableName, List<Dictionary<string, object>> data)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            await connection.OpenAsync();

            foreach (var row in data)
            {
                var columnNames = string.Join(", ", row.Keys.Select(k => "\"" + k + "\""));
                var paramNames = string.Join(", ", row.Keys.Select(k => "@" + k));
                var sql = $"INSERT INTO public.\"{tableName}\" ({columnNames}) VALUES ({paramNames})";

                using (var command = new NpgsqlCommand(sql, connection))
                {
                    foreach (var kvp in row)
                    {
                        var value = kvp.Value;

                        if (value is DateTimeOffset dto)
                        {
                            value = dto.ToUniversalTime();
                        }

                        command.Parameters.AddWithValue("@" + kvp.Key, value ?? DBNull.Value);
                    }

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }

}