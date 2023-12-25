namespace ConsoleApp1;

public class Dollar : Money
{
    public Dollar(int amount)
    {
        Amount = amount;
    }

    public override Money Multiply(int multiplier)
    {
        var amount = Amount * multiplier;
        return new Dollar(amount);
    }
}