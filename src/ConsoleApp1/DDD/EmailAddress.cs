namespace ConsoleApp1.DDD;

public class EmailAddress(string address)
{
    private readonly string _address = address;

    public EmailAddress Parse(string address)
    {
        return new EmailAddress(address);
    }

    public override bool Equals(object? obj)
    {
        var other = obj as EmailAddress;
        return other?._address == _address;
    }

    public static bool operator ==(EmailAddress left, EmailAddress right)
    {
        return left?.Equals(right) ?? ReferenceEquals(right, null);
    }

    public static bool operator !=(EmailAddress left, EmailAddress right)
    {
        return !(left == right);
    }

    public override int GetHashCode()
    {
        return _address.GetHashCode();
    }
}