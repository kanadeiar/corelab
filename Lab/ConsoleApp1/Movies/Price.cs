using static ConsoleApp1.Movies.Price;

namespace ConsoleApp1.Movies;

public abstract class Price
{
    public abstract PriceType GetPriceCode();
    public abstract double GetCharge(int daysRented);
    
    public virtual int GetFrequentRenterPoints(int daysRented)
    {
        return 1;
    }
}