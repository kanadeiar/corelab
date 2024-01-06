namespace ConsoleApp1.Movies;

public class Customer
{
    public string Name { get; set; }
    public List<Rental> Rentals { get; set; } = new List<Rental>();

    public Customer(string name)
    {
        Name = name;
    }

    public void Add(Rental rental)
    {
        Rentals.Add(rental);
    }

    public string Statement()
    {
        var totalAmount = 0d;
        var frequentRenterPoints = 0;
        var rentals = Rentals.GetEnumerator();
        var result = $"Прокат {Name}\n";

        while (rentals.MoveNext())
        {
            var thisAmount = 0d;
            var each = rentals.Current;
            switch (each.Movie.Type)
            {
                case Movie.MovieType.Regular:
                    thisAmount += 2;
                    if (each.DaysRented > 2)
                    {
                        thisAmount += (each.DaysRented - 2) * 1.5;
                    }
                    break;
                case Movie.MovieType.NewRelease:
                    thisAmount += each.DaysRented * 3;
                    break;
                case Movie.MovieType.Children:
                    thisAmount += 1.5;
                    if (each.DaysRented > 3)
                    {
                        thisAmount += (each.DaysRented - 3) * 1.5;
                    }
                    break;
            }
            frequentRenterPoints++;
            if (each.Movie.Type == Movie.MovieType.NewRelease && each.DaysRented > 1)
            {
                frequentRenterPoints++;
            }

            result += $"\t{each.Movie.Title}\t{thisAmount}\n";
            totalAmount += thisAmount;
        }

        result += $"Сумма задолженности: {totalAmount}\nЗаработано {frequentRenterPoints} бонусных очков";

        return result;
    }
}