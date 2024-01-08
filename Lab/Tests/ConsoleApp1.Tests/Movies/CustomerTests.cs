using ConsoleApp1.Movies;

namespace ConsoleApp1.Tests.Movies;

public class CustomerTests
{
    [Fact]
    public void TestAdd()
    {
        var expected = new Rental(new Movie("Тест1", PriceType.Regular), 1);
        var customer = new Customer("Test");

        customer.Add(expected);

        Assert.Contains(expected, customer.Rentals);
    }

    [Fact]
    public void TestStatementWhenNone()
    {
        var customer = new Customer("Test");

        var actual = customer.Statement();

        Assert.Equal("Прокат Test\nСумма задолженности: 0\nЗаработано 0 бонусных очков", actual);
    }

    [Fact]
    public void TestStatement()
    {
        var expected = "Прокат Test\n\tТест1\t3,5\n\tТест2\t6\n\tТест3\t3\nСумма задолженности: 12,5\nЗаработано 4 бонусных очков";
        var testMovie1 = new Movie("Тест1", PriceType.Regular);
        var testMovie2 = new Movie("Тест2", PriceType.NewRelease);
        var testMovie3 = new Movie("Тест3", PriceType.Children);
        var customer = new Customer("Test")
        {
            Rentals = new List<Rental>
            {
                new(testMovie1, 3),
                new(testMovie2, 2),
                new(testMovie3, 4),
            }
        };

        var actual = customer.Statement();

        Assert.Equal(expected, actual);
    }
}