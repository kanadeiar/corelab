namespace ConsoleApp1.Theater;

public class Invoice
{
    public string Cusomer { get; set; }
    public IEnumerable<Performance> Performances { get; set; } = Enumerable.Empty<Performance>();
}