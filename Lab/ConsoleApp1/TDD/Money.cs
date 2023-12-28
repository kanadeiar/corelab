namespace ConsoleApp1.TDD;

public class Money : IExpression
{
    public int Amount;
    private string _currency;
    
    public Money(int amount, string currency)
    {
        Amount = amount;
        _currency = currency;
    }

    public static Money Dollar(int amount)
    {
        return new Money(amount, "USD");
    }
    public static Money Franc(int amount)
    {
        return new Money(amount, "CHF");
    }

    public IExpression Plus(Money addend)
    {
        var sum = new Sum(this, addend);
        return sum;
    }

    public Money Multiply(int multiplier)
    {
        var amount = Amount * multiplier;
        return new Money(amount, _currency);
    }

    public Money Reduce(Bank bank, string to)
    {
        var rate = bank.Rate(_currency, to);
        return new Money(Amount / rate, to);
    }

    public override bool Equals(object? obj)
    {
        var money = (Money)obj;
        return Amount == money.Amount 
               && GetCurrency().Equals(money.GetCurrency());
    }
    
    public string GetCurrency() => _currency;
}