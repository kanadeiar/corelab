using ConsoleApp1.File;

namespace ConsoleApp1;

public record Worker : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Birthday { get; set;}
}