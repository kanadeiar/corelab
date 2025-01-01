namespace ConsoleApp1.DDD;

public class CountryCode(string code)
{
    private string _code = code;

    public static CountryCode Parse(string code)
    {
        return new CountryCode(code);
    }

    public override bool Equals(object? obj)
    {
        var other = obj as CountryCode;
        return other?._code == _code;
    }

    public static bool operator ==(CountryCode left, CountryCode right)
    {
        return left?.Equals(right) ?? ReferenceEquals(right, null);
    }

    public static bool operator !=(CountryCode left, CountryCode right)
    {
        return !(left == right);
    }

    public override int GetHashCode()
    {
        return _code.GetHashCode();
    }
}