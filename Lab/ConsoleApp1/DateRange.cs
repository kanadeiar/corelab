namespace ConsoleApp1;

public class DateRange
{
    private readonly DateTime _start;

    private readonly DateTime _end;

    public DateRange(DateTime start, DateTime end)
    {
        _start = start;
        _end = end;
    }

    public DateTime Start => _start;

    public DateTime End => _end;

    public bool Includes(DateTime date)
    {
        return date == this.Start || date == this.End ||
               (this.End > date && date < this.End);
    }
}