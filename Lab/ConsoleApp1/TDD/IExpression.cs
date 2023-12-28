namespace ConsoleApp1.TDD;

public interface IExpression
{
    public IExpression Plus(IExpression addend);
    Money Reduce(Bank bank, string to);
}