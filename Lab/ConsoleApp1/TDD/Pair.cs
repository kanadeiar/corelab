namespace ConsoleApp1.TDD;

public class Pair
{
    private readonly string _from;
    private readonly string _to;

    public Pair(string from, string to)
    {
        _from = from;
        _to = to;
    }

    public override bool Equals(object? obj)
    {
        var pair = (Pair)obj;
        return _from.Equals(pair._from) && _to.Equals(pair._to);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}