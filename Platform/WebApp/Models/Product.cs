using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models;

public class Product
{
    [Display(Name = "Идентификатор")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Введите значение")]
    [Display(Name = "Название")]
    public string Name { get; set; }

    //[DisplayFormat(DataFormatString = "{0:c2}", ApplyFormatInEditMode = true)]
    //[BindNever]    
    [Required(ErrorMessage = "Введите значение")]
    [Column(TypeName = "decimal(8, 2)")]
    [Range(1, 999999, ErrorMessage = "Введите положительное число")]
    [Display(Name = "Цена")]
    public decimal Price { get; set; }

    public int CategoryId { get; set; }
    //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Category? Category { get; set; }

    public int SupplierId { get; set; }
    //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Supplier? Suppliler { get; set; }
}
