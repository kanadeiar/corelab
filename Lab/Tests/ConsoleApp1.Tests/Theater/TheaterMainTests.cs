using ConsoleApp1.Theater;

namespace ConsoleApp1.Tests.Theater;

public class TheaterMainTests
{
    [Fact]
    public void TestStatement()
    {
        var expected = "Расчет театрального представления для Test\n Тест1: 650 р (55 мест)\n Тест2: 580 р (35 мест)\n Тест3: 500 р (40 мест)\nВся стоимость: 1730 р\nНакоплено 47 бонусных очков";
        var plays = new List<Play>
        {
            new() { Id = 1, Name = "Тест1", Type = "tragedy" }, 
            new() { Id = 2, Name = "Тест2", Type = "comedy" },
            new() { Id = 3, Name = "Тест3", Type = "tragedy" },
        };
        var invoice = new Invoice
        {
            Cusomer = "Test", 
            Performances = new List<Performance>
            {
                new() { PlayId = 1, Audience = 55 },
                new() { PlayId = 2, Audience = 35 },
                new() { PlayId = 3, Audience = 40 },
            }
        };

        var theater = new TheaterMain(plays);

        var actual = theater.Statement(invoice);

        Assert.Equal(expected, actual);
    }
}