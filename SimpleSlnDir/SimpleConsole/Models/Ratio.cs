namespace SimpleConsole.Models;

public class Ratio : BaseEntity
{
    public string RatioId { get; set; }
    public int SampleId { get; set; }
    public Sample SampleNavigation { get; set; }
}