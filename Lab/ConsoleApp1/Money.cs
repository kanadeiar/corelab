namespace ConsoleApp1;

public abstract class Money
{
    protected int Amount;
    private string _currency;

    public static Money Dollar(int amount)
    {
        return new Dollar(amount, "USD");
    }

    public static Money Franc(int amount)
    {
        return new Franc(amount, "CHF");
    }

    public Money(int amount, string currency)
    {
        Amount = amount;
        _currency = currency;
    }

    public override bool Equals(object? obj)
    {
        var money = (Money)obj;
        return Amount == money.Amount && GetType() == money.GetType();
    }

    public abstract Money Multiply(int multiplier);

    public virtual string GetCurrency()
    {
        return _currency;
    }
}