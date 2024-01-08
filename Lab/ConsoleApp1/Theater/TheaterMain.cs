namespace ConsoleApp1.Theater;

struct StatementData
{
    public string Customer { get; set; }
    public IEnumerable<Performance> Performances { get; set; }

}

public class TheaterMain
{
    private readonly IEnumerable<Play> _plays;
    private StatementData _data;

    public TheaterMain(IEnumerable<Play> plays)
    {
        _plays = plays;
    }

    public string Statement(Invoice invoice)
    {
        var data = new StatementData();
        data.Customer = invoice.Customer;
        data.Performances = invoice.Performances;
        return renderPlainText(data);
    }

    private string renderPlainText(StatementData data)
    {
        _data = data;
        var result = $"Расчет театрального представления для {data.Customer}\n";

        foreach (var perf in data.Performances)
        {
            result += $" {playFor(perf).Name}: {rub(amountFor(perf))} р ({perf.Audience} мест)\n";
        }

        result += $"Вся стоимость: {rub(totalAmount())} р\n";
        result += $"Накоплено {totalVolumeCreditsFor()} бонусных очков";

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

    private double totalAmount()
    {
        var result = 0d;
        foreach (var perf in _data.Performances)
        {
            result += amountFor(perf);
        }

        return result;
    }

    private int totalVolumeCreditsFor()
    {
        var result = 0;
        foreach (var perf in _data.Performances)
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