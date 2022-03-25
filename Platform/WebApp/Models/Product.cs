using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp.Data;
using WebApp.Validation;

namespace WebApp.Models;

//[PhraseAndPrice(Phrase = "Small", Price = "100")]
public class Product
{
    [Display(Name = "Идентификатор")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Введите значение")]
    [Display(Name = "Название")]
    public string Name { get; set; }

    //[Column(TypeName = "decimal(8, 2)")]
    [Range(1, 999999, ErrorMessage = "Введите положительное число")]
    [Display(Name = "Цена")]
    [DataType(DataType.Currency)]
    [Precision(8, 2)]
    [DisplayFormat(DataFormatString = "{0:0}", ApplyFormatInEditMode = true)]
    public decimal Price { get; set; }

    [PrimaryKey(ContextType = typeof(DataContext), DataType = typeof(Category))]
    public int CategoryId { get; set; }
    public Category? Category { get; set; }

    [PrimaryKey(ContextType = typeof(DataContext), DataType = typeof(Supplier))]
    public int SupplierId { get; set; }
    public Supplier? Suppliler { get; set; }
}
