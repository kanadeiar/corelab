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
        var result = $"Прокат {Name}\n";
        foreach (var el in Rentals)
        {
            result += $"\t{el.GetTitle()}\t{el.GetCharge()}\n";
        }
        result += $"Сумма задолженности: {getTotalCharge()}\nЗаработано {getTotalFrequentRenterPoints()} бонусных очков";

        return result;
    }

    private double getTotalCharge()
    {
        return Rentals.Sum(el => el.GetCharge());
    }

    private int getTotalFrequentRenterPoints()
    {
        return Rentals.Sum(el => el.GetFrequentRenterPoints());
    }
}