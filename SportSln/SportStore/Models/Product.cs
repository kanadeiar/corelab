namespace SportStore.Models;

public class Product
{
    public long Id { get; set; }
    [Required(ErrorMessage = "Please enter a product name")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Please enter a description")]
    public string Description { get; set; }
    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "Please enter positive value")]
    [Column(TypeName = "decimal(8,2)")]
    public decimal Price { get; set; }
    [Required(ErrorMessage = "Please specify a category")]
    public string Category { get; set; }
}