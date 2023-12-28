namespace ConsoleApp1.TDD;

public class Bank
{
    private Dictionary<Pair, int> _rates = new Dictionary<Pair, int>();

    public Money Reduce(IExpression from, string to)
    {
        return from.Reduce(this, to);
    }

    public int Rate(string from, string to)
    {
        if (from.Equals(to))
            return 1;
        var rate = _rates[new Pair(from, to)];
        return rate;
    }

    public void AddRate(string from, string to, int rate)
    {
        _rates.Add(new Pair(from, to), rate);
    }
}