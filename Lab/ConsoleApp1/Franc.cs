namespace ConsoleApp1;

public class Franc : Money
{
    public Franc(int amount)
    {
        Amount = amount;
    }

    public override Money Multiply(int multiplier)
    {
        var amount = Amount * multiplier;
        return new Franc(amount);
    }
}