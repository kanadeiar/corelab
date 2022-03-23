using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Validation;

public class PrimaryKeyAttribute : ValidationAttribute
{
    public Type? ContextType { get; set; }
    public Type? DataType { get; set; }
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (ContextType != null && DataType != null)
        {
            var context = validationContext.GetService(ContextType) as DbContext;
            if (context != null && context.Find(DataType, value) == null)
            {
                return new ValidationResult(ErrorMessage ?? "Введите существующее значение ключа");
            }
        }
        return ValidationResult.Success;
    }
}
