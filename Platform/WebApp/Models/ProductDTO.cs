using AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models;

public class ProductDTO
{
    [Required]
    public string Name { get; set; }
    [Range(1,1000)]
    public decimal Price { get; set; }
    [Range(1, int.MaxValue)]
    public int CategoryId { get; set; }
    [Range(1, int.MaxValue)]
    public int SupplierId { get; set; }

    public static implicit operator Product(ProductDTO param)
    {
        return new Product
        {
            Name = param.Name,
            Price = param.Price,
            CategoryId = param.CategoryId,
            SupplierId = param.SupplierId,
        };
    }
    public static implicit operator ProductDTO(Product param)
    {
        return new ProductDTO
        {
            Name = param.Name,
            Price = param.Price,
            CategoryId = param.CategoryId,
            SupplierId = param.SupplierId,
        };
    }
}


