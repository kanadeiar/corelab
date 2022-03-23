using System.ComponentModel.DataAnnotations;
using WebApp.Models;

namespace WebApp.Validation;

public class PhraseAndPriceAttribute : ValidationAttribute
{
    public string? Phrase { get; set; }
    public string? Price { get; set; }
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value != null && validationContext != null)
        {
            var product = value as Product;
            if (product != null && product.Name.StartsWith(Phrase, StringComparison.OrdinalIgnoreCase) && product.Price > decimal.Parse(Price))
            {
                return new ValidationResult(ErrorMessage ?? $"{Phrase} товар не может быть больше чем {Price}");
            }
        }
        return ValidationResult.Success;
    }
}
