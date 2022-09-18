namespace SimpleConsole.Models;

public class Driver : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public IEnumerable<Sample> Samples { get; set; } = new List<Sample>();
}