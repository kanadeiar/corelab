using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    [Column(TypeName = "decimal(8, 2)")]
    public decimal Price { get; set; }
    public int CaregoryId { get; set; }
    public Category Category { get; set; }
    public int SupplierId { get; set; }
    public Supplier Suppliler { get; set; }
}
