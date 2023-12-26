namespace ConsoleApp1;

public class Franc : Money
{
    public Franc(int amount, string currency) : base(amount, currency)
    {

    }

    public override Money Multiply(int multiplier)
    {
        var amount = Amount * multiplier;
        return Franc(amount);
    }
}