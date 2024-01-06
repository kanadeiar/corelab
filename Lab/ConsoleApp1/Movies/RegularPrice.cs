namespace ConsoleApp1.Movies;

public class RegularPrice : Price
{
    public override PriceType GetPriceCode()
    {
        return PriceType.Regular;
    }

    public override double GetCharge(int daysRented)
    {
        var result = 2d;
        if (daysRented > 2)
        {
            result += (daysRented - 2) * 1.5;
        }
        return result;
    }
}