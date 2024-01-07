namespace ConsoleApp1.Movies.Internals;

internal class NewReleasePrice : Price
{
    public override PriceType GetPriceCode()
    {
        return PriceType.NewRelease;
    }

    public override double GetCharge(int daysRented)
    {
        return daysRented * 3;
    }

    public override int GetFrequentRenterPoints(int daysRented)
    {
        return daysRented > 1
            ? 2
            : 1;
    }
}