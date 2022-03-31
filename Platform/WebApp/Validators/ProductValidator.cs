using FluentValidation;
using WebApp.Models;

namespace WebApp.Validators;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(x => x.Name).NotNull().NotEmpty().Length(3, 30).WithMessage("Нужно ввести название длинной от 3 до 30 символов");
    }
}
