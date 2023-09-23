using System.Data;
using System.Data.Common;
using AutoLot.Dal.DataOperations;
using AutoLot.Dal.Models;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace ConsoleApp1;

static class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Опытное приложение работы с базой данных");
        var connectionString = getProviderFromConfiguration();

        using var dal = new InventoryDal(connectionString);
        foreach (var car in dal.GetAllView())
        {
            Console.WriteLine($"{car.Id} {car.Make} {car.Name} {car.Color}");
        }

        var carView = dal.GetView(3);


        var newCar = new Car
        {
            MakeId = 2,
            Name = "Тестовое",
            Color = "Тестовый",
        };
        dal.Add(newCar);
        var carOld = dal.Get(16);
        carOld.Name = "Изменное имя";
        dal.Update(carOld.Id, carOld);
        foreach (var car in dal.GetAllView())
        {
            Console.WriteLine($"{car.Id} {car.Make} {car.Name} {car.Color}");
        }
        dal.Delete(13);
        Console.WriteLine("После удаления:");
        foreach (var car in dal.GetAllView())
        {
            Console.WriteLine($"{car.Id} {car.Make} {car.Name} {car.Color}");
        }


        //        using (var connection = new NpgsqlConnection(connectionString))
        //        {
        //            connection.Open();
        //            var command = connection.CreateCommand();
        //            command.CommandText = @"SELECT i.Id, m.Name as Make, i.Name, i.Color 
        //FROM inventory i 
        //INNER JOIN makes m ON m.Id = i.MakeId";
        //            using (var dataReader = command.ExecuteReader())
        //            {
        //                Console.WriteLine("***** Current Inventory *****");
        //                while (dataReader.Read())
        //                {
        //                    for (int i = 0; i < dataReader.FieldCount; i++)
        //                    {
        //                        Console.Write($"{dataReader.GetName(i)}={dataReader.GetValue(i)} ");
        //                    }
        //                    Console.WriteLine();
        //                    //Console.WriteLine($"-> #{dataReader["Id"]}. {dataReader["Make"]} {dataReader["Name"]} - {dataReader["Color"]}.");
        //                }
        //            }
        //        }


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



