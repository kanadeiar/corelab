namespace ConsoleApp1.DDD;

public class Height(int height)
{
    private readonly int _height = height;

    public static Height Metric(int value)
    {
        return new Height(value);
    }

    public override bool Equals(object? obj)
    {
        var other = obj as Height;
        return other?._height == _height;
    }

    public static bool operator ==(Height left, Height right)
    {
        return left?.Equals(right) ?? ReferenceEquals(right, null);
    }

    public static bool operator !=(Height left, Height right)
    {
        return !(left == right);
    }

    public override int GetHashCode()
    {
        return _height.GetHashCode();
    }
}