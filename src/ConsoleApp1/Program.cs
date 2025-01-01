using ConsoleApp1.DDD;

namespace ConsoleApp1;

public static class Program
{
    public static void Main(string[] args)
    {
        ConsoleHelper.PrintHeader("Лаборатория", "Опытное приложение");

        var person = new Person(
            new PersonId(1),
            new PersonName("Ivanov", "Ivan"),
            new PhoneNumber("12323"),
            new PhoneNumber("1233"),
            new EmailAddress("one@ii.ru"),
            Height.Metric(234),
            CountryCode.Parse("RU"));


        ConsoleHelper.PrintFooter();
    }
}