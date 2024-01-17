namespace ConsoleApp1;

public class Entry
{
    private DateTime _date;

    public DateTime Date => _date;

    private double _value;

    public double Value => _value;

    public Entry(DateTime date, double value)
    {
        _date = date;
        _value = value;
    }
}