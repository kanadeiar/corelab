using ConsoleApp1.Movies;

namespace ConsoleApp1;

static class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Видеопрокат");

        var testMovie1 = new Movie("Тест1", Movie.MovieType.Regular);
        var testMovie2 = new Movie("Тест2", Movie.MovieType.NewRelease);
        var testMovie3 = new Movie("Тест3", Movie.MovieType.Children);
        var movies = new List<Movie>
        {
            testMovie1,
            testMovie2,
            testMovie3,
        };
        var customer = new Customer("Test")
        {
            Rentals = new List<Rental>
            {
                new(testMovie1, 3),
                new(testMovie2, 2),
                new(testMovie3, 1),
            }
        };

        var text = customer.Statement();
        Console.WriteLine(text);

        Console.WriteLine("Нажмиту любую кнопку ...");
        Console.ReadKey();
    }


}

