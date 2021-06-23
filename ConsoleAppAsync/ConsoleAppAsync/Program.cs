using System;
using System.Threading;


namespace ConsoleAppAsync
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Лаборатория асинхронного кода");


            var my = new MyClass();
            my.Message("one");


            Console.Title = "Завершено";
            Console.WriteLine("Нажмите любую кнопку для закрытия ...");
            Console.ReadLine();
        }


    }

    class MyClass
    {
        public void Message(string message)
        {
            GetHostAddress("one.ru", ResolveMesssage);
        }

        private void ResolveMesssage(string message)
        {
            Console.WriteLine($"mess: {message}");
        }

        void GetHostAddress(string host, Action<string> callback)
        {
            Thread.Sleep(1000);
            callback.Invoke(host);
        }
    }
}
