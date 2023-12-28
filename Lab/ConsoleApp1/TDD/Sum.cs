namespace ConsoleApp1.TDD;

public class Sum : IExpression
{
    public IExpression Augend { get; }
    public IExpression Addend { get; }

    public Sum(IExpression augend, IExpression addend)
    {
        Augend = augend;
        Addend = addend;
    }

    public IExpression Plus(IExpression addend)
    {
        return null;
    }

    public Money Reduce(Bank bank, string to)
    {
        var amount = Augend.Reduce(bank, to).Amount + Addend.Reduce(bank, to).Amount;
        return new Money(amount, to);
    }
}