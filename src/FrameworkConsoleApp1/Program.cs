using System;
using FrameworkConsoleApp1.Models;

namespace FrameworkConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Опытное .NET Framework приложение");

            var person1 = new Person { Name = "Name1" };
            var person2 = new Person { Name = "Name2" };
            var contorol1 = new PersonControl(person1);
            var contorol2 = new PersonControl(person2);
            
            var controller = new Controller();

            controller.AddPersonControl(contorol1);
            controller.AddPersonControl(contorol2);

            foreach (var each in controller.GetPersons)
            {
                Console.WriteLine(each.Name);
            }

            controller.RemovePersonControl(contorol1);

            Console.WriteLine("After:");

            foreach (var each in controller.GetPersons)
            {
                Console.WriteLine(each.Name);
            }

            Console.WriteLine("Нажмите любую кнопку для завершения ...");
            Console.ReadKey();
        }
    }
}
