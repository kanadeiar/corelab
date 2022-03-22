using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApp.Models;

public class Product
{
    [Display(Name = "Идентификатор")]
    public int Id { get; set; }
    [Display(Name = "Название")]
    public string Name { get; set; }
    [Display(Name = "Цена")]
    [Column(TypeName = "decimal(8, 2)")]
    //[DisplayFormat(DataFormatString = "{0:c2}", ApplyFormatInEditMode = true)]
    //[BindNever]
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Category Category { get; set; }
    public int SupplierId { get; set; }
    //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Supplier Suppliler { get; set; }
}
