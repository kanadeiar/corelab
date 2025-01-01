namespace ConsoleApp1.DDD;

public class PhoneNumber(string number)
{
    private readonly string _number = number;

    public PhoneNumber Parse(string number)
    {
        return new PhoneNumber(number);
    }

    public override bool Equals(object? obj)
    {
        var other = obj as PhoneNumber;
        return other?._number == _number;
    }

    public static bool operator ==(PhoneNumber left, PhoneNumber right)
    {
        return left?.Equals(right) ?? ReferenceEquals(right, null);
    }

    public static bool operator !=(PhoneNumber left, PhoneNumber right)
    {
        return !(left == right);
    }

    public override int GetHashCode()
    {
        return _number.GetHashCode();
    }
}