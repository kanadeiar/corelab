namespace SimpleConsole.Models;

public class Ratio : BaseEntity
{
    public string RatioId { get; set; } = string.Empty;
    public int SampleId { get; set; }
    public virtual Sample SampleNavigation { get; set; } = null!;
}