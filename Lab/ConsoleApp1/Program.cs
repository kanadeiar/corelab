using System.Data;
using System.Data.Common;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace ConsoleApp1;

static class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Опытное приложение работы с базой данных");
        var connectionString = getProviderFromConfiguration();

        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = @"SELECT i.Id, m.Name as Make, i.Name, i.Color 
FROM inventory i 
INNER JOIN makes m ON m.Id = i.MakeId";
            using (var dataReader = command.ExecuteReader())
            {
                Console.WriteLine("***** Current Inventory *****");
                while (dataReader.Read())
                {
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        Console.Write($"{dataReader.GetName(i)}={dataReader.GetValue(i)} ");
                    }
                    Console.WriteLine();
                    //Console.WriteLine($"-> #{dataReader["Id"]}. {dataReader["Make"]} {dataReader["Name"]} - {dataReader["Color"]}.");
                }
            }
        }


        Console.WriteLine("Нажмиту любую кнопку ...");
        Console.ReadKey();

    }


    static string getProviderFromConfiguration()
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        var providerName = config["ProviderName"];
        return config[$"{providerName}:ConnectionString"];
    }
}



