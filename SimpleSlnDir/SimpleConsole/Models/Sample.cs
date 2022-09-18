namespace SimpleConsole.Models;

public class Sample : BaseEntity
{
    public string Name { get; set; }
    public int MakeId { get; set; }
    public Make MakeNavigation { get; set; }
    public Ratio RatioNavigation { get; set; }
    public IEnumerable<Driver> Drivers { get; set; } = new List<Driver>();
}