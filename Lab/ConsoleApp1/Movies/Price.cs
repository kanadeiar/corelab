using static ConsoleApp1.Movies.Price;

namespace ConsoleApp1.Movies;

public abstract class Price
{
    public static Price Create(PriceType priceType)
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


    public abstract PriceType GetPriceCode();
    public abstract double GetCharge(int daysRented);
    
    public virtual int GetFrequentRenterPoints(int daysRented)
    {
        return 1;
    }
}