using ConsoleApp1.Theater.Internals;

namespace ConsoleApp1.Theater;

public class TheaterMain
{
    private readonly StatementDataCreator _statementDataCreator;

    public TheaterMain(IEnumerable<Play> plays)
    {
        _statementDataCreator = new StatementDataCreator(plays);
    }

    public string Statement(Invoice invoice)
    {
        return renderPlainText(_statementDataCreator.CreateStatementData(invoice));
    }

    private string renderPlainText(StatementData data)
    {
        var result = $"Расчет театрального представления для {data.Customer}\n";

        foreach (var perf in data.Performances)
        {
            result += $" {perf.Play.Name}: {rub(perf.Amount)} ({perf.Audience} мест)\n";
        }

        result += $"Вся стоимость: {rub(data.TotalAmount)}\n";
        result += $"Накоплено {data.TotalVolumeCredits} бонусных очков";

        return result;
    }

    public string HtmlStatement(Invoice invoice)
    {
        return renderHtmlPlainText(_statementDataCreator.CreateStatementData(invoice));
    }

    private string renderHtmlPlainText(StatementData data)
    {
        var result = $"<h1>Расчет для {data.Customer}</h1>\n";

        result += "<table>\n";
        foreach (var perf in data.Performances)
        {
            result += $"<tr><td>{perf.Play.Name}</td><td>{rub(perf.Amount)}</td><td>{perf.Audience}</td></tr>\n";
        }
        result += "</table>\n";

        result += $"<p>Вся стоимость: {rub(data.TotalAmount)}</p>\n";
        result += $"<p>Накоплено {data.TotalVolumeCredits} бонусных очков</p>";

        return result;
    }

    private string rub(double value)
    {
        return (value / 100).ToString() + " р";
    }
}