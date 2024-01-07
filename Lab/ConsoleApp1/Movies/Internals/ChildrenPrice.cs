namespace ConsoleApp1.Movies.Internals;

internal class ChildrenPrice : Price
{
    public override PriceType GetPriceCode()
    {
        return PriceType.Children;
    }

    public override double GetCharge(int daysRented)
    {
        var result = 1.5d;
        if (daysRented > 3)
        {
            result += (daysRented - 3) * 1.5;
        }
        return result;
    }
}