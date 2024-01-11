namespace ConsoleApp1;


public class IntRange
{
    private int _low;
    public int Low
    {
        get => _low;
        set => _low = value;
    }

    private int _high;
    public int High
    {
        get => _high;
        set => _high = value;
    }

    protected IntRange() { }
    public IntRange(int low, int high)
    {
        create(low, high);
    }
    protected void create(int low, int high)
    {
        _low = low;
        _high = high;
    }

    public bool Includes(int value)
    {
        return _low <= value && value <= _high;
    }

    public void Grow(int factor)
    {
        High *= factor;
    }
}

public class CappedRange : IntRange
{
    private int _cap;

    public int Cap
    {
        get => _cap;
        set => _cap = value;
    }

    public new int High
    {
        get => Math.Min(_cap, base.High);
    }

    public CappedRange(int low, int high, int cap)
    {
        create(low, high);
        _cap = cap;
    }
}

public class Refactoring
{


}
