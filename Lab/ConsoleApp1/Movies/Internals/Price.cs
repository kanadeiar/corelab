namespace ConsoleApp1.Movies.Internals;

internal abstract class Price
{
    public abstract PriceType GetPriceCode();
    public abstract double GetCharge(int daysRented);

    public virtual int GetFrequentRenterPoints(int daysRented)
    {
        return 1;
    }
}