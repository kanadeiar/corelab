using System.ComponentModel.DataAnnotations;

namespace WebApp.Models;

public class Category
{
    public int Id { get; set; }
    [Display(Name = "Название категории")]
    public string Name { get; set; }
    public IEnumerable<Product> Products { get; set; }
}
