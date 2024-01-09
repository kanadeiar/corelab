namespace ConsoleApp1.Theater.Internals;

internal class TragedyCalculator : PerformanceCalculator
{
    private readonly Performance _performance;

    public TragedyCalculator(Performance performance, Play play) : base(performance, play)
    {
        _performance = performance;
    }

    public override double Amount()
    {
        var result = 40000;
        if (_performance.Audience > 30)
        {
            result += 1000 * (_performance.Audience - 30);
        }
        return result;
    }
}