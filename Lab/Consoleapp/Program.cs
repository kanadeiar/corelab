Console.WriteLine("Лабораторное приложение");

var arrow1 = new Arrow(Arrowhead.Steel, 60, Fletching.Plastic);
Console.WriteLine($"Стоимость: {arrow1.GetCost().ToString()} золота.");

Console.WriteLine("Нажми любую кнопку ...");
var _ = Console.ReadKey();

public class Arrow
{
    public Arrowhead Arrowhead { get; set; }
    private double _shaft;
    public double Shaft
    {
        get => _shaft;
        set
        {
            if (value < 100.0 && value > 60.0)
            {
                _shaft = value;
            }
        }
    }
    public Fletching Fletching { get; set; }
    public Arrow(Arrowhead arrowhead, double shaft, Fletching fletching)
    {
        Arrowhead = arrowhead;
        Shaft = shaft;
        Fletching = fletching;
    }
    public double GetCost()
    {
        var costHead = Arrowhead switch
        {
            Arrowhead.Steel => 10,
            Arrowhead.Wood => 3,
            _ => 5,
        };
        var costShaft = Shaft * 0.05;
        var costFletching = Fletching switch
        {
            Fletching.Plastic => 10,
            Fletching.TurkeyFeathers => 5,
            _ => 3,
        };
        return costHead * costShaft * costFletching;
    }
}
public enum Arrowhead
{
    Steel,
    Wood,
    Obsidian,
}
public enum Fletching
{
    Plastic,
    TurkeyFeathers,
    GooseFeathers,
}