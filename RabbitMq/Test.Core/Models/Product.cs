namespace Test.Core.Models;

public class Product
{
    public string Id => Guid.NewGuid().ToString();
    public string Slug { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedOn => DateTime.Today.AddYears(-1);
}
