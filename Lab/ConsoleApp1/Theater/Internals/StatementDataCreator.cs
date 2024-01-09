namespace ConsoleApp1.Theater.Internals;

internal class StatementDataCreator
{
    private readonly IEnumerable<Play> _plays;

    public StatementDataCreator(IEnumerable<Play> plays)
    {
        _plays = plays;
    }

    public StatementData CreateStatementData(Invoice invoice)
    {
        var result = new StatementData();
        result.Customer = invoice.Customer;
        result.Performances = invoice.Performances
            .Select(perf => (IPerformance)enrichPerformance(perf)).ToList();
        result.TotalAmount = totalAmount(result);
        result.TotalVolumeCredits = totalVolumeCredits(result);
        return result;
    }

    private PerformanceData enrichPerformance(Performance aPerf)
    {
        var calculator = createPerformanceCalculator(aPerf, playFor(aPerf.PlayId));
        var perfData = new PerformanceData
        {
            PlayId = aPerf.PlayId,
            Audience = aPerf.Audience,
            Play = calculator.Play,
            Amount = calculator.Amount(),
            VolumeCredits = calculator.VolumeCredits()
        };
        return perfData;
    }

    private PerformanceCalculator createPerformanceCalculator(Performance aPerf, Play play)
    {
        switch (play.Type)
        {
            case "tragedy":
                return new TragedyCalculator(aPerf, play);
            case "comedy":
                return new ComedyCalculator(aPerf, play);
            default:
                throw new ArgumentOutOfRangeException(nameof(play.Type));
        }
    }

    private Play playFor(int playId)
    {
        return _plays.Single(pl => pl.Id == playId);
    }

    private double totalAmount(StatementData data)
    {
        var result = 0d;
        foreach (var perf in data.Performances)
        {
            result += perf.Amount;
        }

        return result;
    }

    private int totalVolumeCredits(StatementData data)
    {
        var result = 0;
        foreach (var perf in data.Performances)
        {
            var res = perf.VolumeCredits;
            result += res;
        }

        return result;
    }
}