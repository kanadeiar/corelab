namespace ConsoleApp1.TDD;

public interface IExpression
{
    Money Reduce(Bank bank, string to);
}