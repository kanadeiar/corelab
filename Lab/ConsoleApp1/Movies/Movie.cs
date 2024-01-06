namespace ConsoleApp1.Movies;

public class Movie
{
    private Price _price;
    public string Title { get; init; }
    
    public Movie(string title, PriceType priceType)
    {
        Title = title;
        _price = Price.Create(priceType);
    }

    public double GetCharge(int daysRented)
    {
        return _price.GetCharge(daysRented);
    }

    public int GetFrequentRenterPoints(int daysRented)
    {
        return _price.GetFrequentRenterPoints(daysRented);
    }
}