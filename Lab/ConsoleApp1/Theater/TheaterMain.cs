namespace ConsoleApp1.Theater;

public class TheaterMain
{
    private readonly IEnumerable<Play> _plays;

    public TheaterMain(IEnumerable<Play> plays)
    {
        _plays = plays;
    }

    public string Statement(Invoice invoice)
    {
        var result = $"Расчет театрального представления для {invoice.Cusomer}\n";

        foreach (var perf in invoice.Performances)
        {
            result += $" {playFor(perf).Name}: {rub(amountFor(perf))} р ({perf.Audience} мест)\n";
        }

        result += $"Вся стоимость: {rub(totalAmount(invoice))} р\n";
        result += $"Накоплено {totalVolumeCreditsFor(invoice.Performances)} бонусных очков";

        return result;
    }

    private Play playFor(Performance perf)
    {
        return _plays.Single(pl => pl.Id == perf.PlayId);
    }

    private string rub(double value)
    {
        return (value / 100).ToString();
    }

    private double amountFor(Performance aPerformance)
    {
        var result = 0d;
        switch (playFor(aPerformance).Type)
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
                throw new IndexOutOfRangeException(playFor(aPerformance).Type);
        }

        return result;
    }

    private double totalAmount(Invoice invoice)
    {
        var result = 0d;
        foreach (var perf in invoice.Performances)
        {
            result += amountFor(perf);
        }

        return result;
    }

    private int totalVolumeCreditsFor(IEnumerable<Performance> performances)
    {
        var result = 0;
        foreach (var perf in performances)
        {
            result += Math.Max(0, perf.Audience - 30);

            if (playFor(perf).Type == "comedy")
            {
                result += perf.Audience / 5;
            }
        }

        return result;
    }
}