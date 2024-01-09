namespace ConsoleApp1.Theater.Internals;

public struct StatementData
{
    public string Customer { get; set; }
    public List<IPerformance> Performances { get; set; }
    public double TotalAmount { get; set; }
    public int TotalVolumeCredits { get; set; }

    public StatementData()
    {
        Performances = new List<IPerformance>();
    }
}