namespace ConsoleApp1.Theater.Internals;

internal class PerformanceCalculator
{
    private readonly Performance _performance;
    private Play _play;

    public Play Play => _play;

    public PerformanceCalculator(Performance performance, Play play)
    {
        _performance = performance;
        _play = play;
    }

    public double Amount()
    {
        double result;
        switch (_play.Type)
        {
            case "tragedy":
                result = 40000;
                if (_performance.Audience > 30)
                {
                    result += 1000 * (_performance.Audience - 30);
                }
                break;
            case "comedy":
                result = 30000;
                if (_performance.Audience > 20)
                {
                    result += 10000;
                    result += 500 * (_performance.Audience - 20);
                }
                result += 300 * _performance.Audience;
                break;
            default:
                throw new IndexOutOfRangeException(Play.Type);
        }

        return result;
    }

    public int VolumeCredits()
    {
        var res = Math.Max(0, _performance.Audience - 30);
        if (Play.Type == "comedy")
        {
            res += _performance.Audience / 5;
        }
        return res;
    }
}