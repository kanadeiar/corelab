namespace ConsoleApp1.Theater.Internals;

struct PerformanceData : IPerformance
{
    public int PlayId { get; set; }
    public int Audience { get; set; }
    public Play Play { get; set; }
    public double Amount { get; set; }
    public int VolumeCredits { get; set; }
}