namespace ConsoleApp1;

public class Refactoring
{
    public double Calculate()
    {
        var acc = new Account();
        acc.Add(new Entry[]
        {
            new(new DateTime(2000, 1, 1), 100.0),
            new(new DateTime(2000, 1, 10), 50.0),
            new(new DateTime(2001, 12, 30), -100.0)
        });

        var range = new DateRange(new DateTime(2000, 1, 1), new DateTime(2000, 2, 2));
        var result = acc.GetFlowBetween(range);

        return result;
    }
}