namespace SimpleConsole.Models;

public class Ratio : BaseEntity
{
    public string RatioId { get; set; }
    public int SampleId { get; set; }
    public virtual Sample SampleNavigation { get; set; }
}