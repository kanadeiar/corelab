namespace ConsoleApp1.TDD;

public interface IExpression
{
    IExpression Plus(IExpression addend);
    IExpression Multiply(int multiplier);
    Money Reduce(Bank bank, string to);
}