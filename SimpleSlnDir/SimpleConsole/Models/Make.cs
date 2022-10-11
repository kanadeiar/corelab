namespace SimpleConsole.Models;

public class Make : BaseEntity
{
    public string Name { get; set; }
    public virtual IEnumerable<Sample> Samples { get; set; } = new List<Sample>();
}