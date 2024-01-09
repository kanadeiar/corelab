namespace ConsoleApp1.Theater.Internals;

internal class ComedyCalculator : PerformanceCalculator
{
    private readonly Performance _performance;

    public ComedyCalculator(Performance performance, Play play) : base(performance, play)
    {
        _performance = performance;
    }

    public override double Amount()
    {
        var result = 30000;
        if (_performance.Audience > 20)
        {
            result += 10000;
            result += 500 * (_performance.Audience - 20);
        }
        result += 300 * _performance.Audience;
        return result;
    }

    public override int VolumeCredits()
    {
        return base.VolumeCredits() + _performance.Audience / 5;
    }
}