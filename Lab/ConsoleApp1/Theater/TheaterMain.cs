namespace ConsoleApp1.Theater;

public class TheaterMain
{
    public string Statement(Invoice invoice, IEnumerable<Play> plays)
    {
        var totalAmount = 0d;
        var volumeCredits = 0;
        var result = $"Расчет театрального представления для {invoice.Cusomer}\n";

        foreach (var perf in invoice.Performances)
        {
            var play = plays.Single(pl => pl.Id == perf.PlayId);
            var thisAmount = 0d;
            switch (play.Type)
            {
                case "tragedy":
                    thisAmount = 40000;
                    if (perf.Audience > 30)
                    {
                        thisAmount += 1000 * (perf.Audience - 30);
                    }
                    break;
                case "comedy":
                    thisAmount = 30000;
                    if (perf.Audience > 20)
                    {
                        thisAmount += 10000;
                        thisAmount += 500 * (perf.Audience - 20);
                    }
                    thisAmount += 300 * perf.Audience;
                    break;
                default:
                    throw new IndexOutOfRangeException(nameof(play.Type));
            }

            // Бонусы
            volumeCredits += Math.Max(0, perf.Audience - 30);

            // Бонус за каждые 10 комедий
            if (play.Type == "comedy")
            {
                volumeCredits += perf.Audience / 5;
            }

            // Вывод строки счета
            result += $" {play.Name}: {thisAmount / 100} р ({perf.Audience} мест)\n";
            totalAmount += thisAmount;
        }

        result += $"Вся стоимость: {totalAmount / 100} р\n";
        result += $"Накоплено {volumeCredits} бонусных очков";

        return result;
    }
}