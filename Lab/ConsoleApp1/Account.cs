namespace ConsoleApp1;

public class Account
{
    private List<Entry> _entries = new List<Entry>();

    public void Add(Entry[] entries)
    {
        _entries.AddRange(entries);
    }

    public void Reset()
    {
        _entries.Clear();
    }

    public double GetFlowBetween(DateRange range)
    {
        var result = 0.0;
        foreach (var ent in _entries)
        {
            if (range.Includes(ent.Date))
            {
                result += ent.Value;
            }
        }
        return result;
    }
}