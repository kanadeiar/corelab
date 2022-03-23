using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp.Data;
using WebApp.Validation;

namespace WebApp.Models;

[PhraseAndPrice(Phrase = "Small", Price = "100")]
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

    [PrimaryKey(ContextType = typeof(DataContext), DataType = typeof(Category))]
    public int CategoryId { get; set; }
    //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Category? Category { get; set; }

    [PrimaryKey(ContextType = typeof(DataContext), DataType = typeof(Category))]
    public int SupplierId { get; set; }
    //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Supplier? Suppliler { get; set; }
}
