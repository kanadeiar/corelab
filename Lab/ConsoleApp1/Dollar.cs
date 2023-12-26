namespace ConsoleApp1;

public class Dollar : Money
{
    public Dollar(int amount, string currency) : base(amount, currency)
    {

    }

    public override Money Multiply(int multiplier)
    {
        var amount = Amount * multiplier;
        return Dollar(amount);
    }
}