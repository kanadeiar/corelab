using System;

namespace ConsoleApp
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            var sample = new Sample();

            var val = await sample.AddMethod(3);

            Console.WriteLine(val);


            Console.WriteLine("Нажать любую кнопку для продолжения ...");
            var _ = Console.ReadKey();
        }
    }
}







