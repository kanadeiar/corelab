namespace ConsoleApp1.Theater.Internals;

public interface IPerformance
{
    int PlayId { get; set; }
    int Audience { get; set; }
    Play Play { get; set; }
    double Amount { get; set; }
    int VolumeCredits { get; set; }
}