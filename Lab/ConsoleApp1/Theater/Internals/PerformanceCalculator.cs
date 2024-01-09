namespace ConsoleApp1.Theater.Internals;

internal abstract class PerformanceCalculator
{
    private readonly Performance _performance;
    private Play _play;

    public Play Play => _play;

    public PerformanceCalculator(Performance performance, Play play)
    {
        _performance = performance;
        _play = play;
    }

    public abstract double Amount();

    public virtual int VolumeCredits()
    {
        return Math.Max(0, _performance.Audience - 30);
    }
}