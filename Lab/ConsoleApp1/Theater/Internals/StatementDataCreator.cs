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
        result.Performances.Clear();
        foreach (var perf in invoice.Performances)
        {
            var perfData = new PerformanceData
            {
                PlayId = perf.PlayId,
                Audience = perf.Audience,
            };
            perfData.Play = playFor(perfData);
            perfData.Amount = amountFor(perfData);
            perfData.VolumeCredits = volumeCreditsFor(perfData);
            result.Performances.Add(perfData);
        }

        result.TotalAmount = totalAmount(result);
        result.TotalVolumeCredits = totalVolumeCredits(result);
        return result;
    }

    private Play playFor(IPerformance perf)
    {
        return _plays.Single(pl => pl.Id == perf.PlayId);
    }

    private double amountFor(IPerformance aPerformance)
    {
        double result;
        switch (aPerformance.Play.Type)
        {
            case "tragedy":
                result = 40000;
                if (aPerformance.Audience > 30)
                {
                    result += 1000 * (aPerformance.Audience - 30);
                }

                break;
            case "comedy":
                result = 30000;
                if (aPerformance.Audience > 20)
                {
                    result += 10000;
                    result += 500 * (aPerformance.Audience - 20);
                }

                result += 300 * aPerformance.Audience;
                break;
            default:
                throw new IndexOutOfRangeException(aPerformance.Play.Type);
        }

        return result;
    }

    private int volumeCreditsFor(IPerformance perf)
    {
        var res = Math.Max(0, perf.Audience - 30);

        if (playFor(perf).Type == "comedy")
        {
            res += perf.Audience / 5;
        }

        return res;
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