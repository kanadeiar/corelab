namespace ConsoleApp1.Movies;

public class Movie
{
    private Price _price;
    public string Title { get; init; }
    
    public Movie(string title, PriceType priceType)
    {
        Title = title;
        _price = create(priceType);
    }

    public double GetCharge(int daysRented)
    {
        return _price.GetCharge(daysRented);
    }

    public int GetFrequentRenterPoints(int daysRented)
    {
        return _price.GetFrequentRenterPoints(daysRented);
    }

    private static Price create(PriceType priceType)
    {
        switch (priceType)
        {
            case PriceType.Regular:
                return new RegularPrice();
            case PriceType.NewRelease:
                return new NewReleasePrice();
            case PriceType.Children:
                return new ChildrenPrice();
            default:
                throw new ArgumentOutOfRangeException("Incorrect PriceType");
        }
    }
}