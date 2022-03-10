using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp;

public static class TestData
{
    public static void SeedDatabase(DataContext context)
    {
        context.Database.Migrate();
        if (context.Products.Any())
        {
            return;
        }
        var s1 = new Supplier
        {
            Name = "Dunes",
            City = "Lose"
        };
        var s2 = new Supplier
        {
            Name = "Tones",
            City = "Chicago"
        };
        var s3 = new Supplier
        {
            Name = "Chess",
            City = "York"
        };
        var c1 = new Category { Name = "Water" };
        var c2 = new Category { Name = "Soccer" };
        var c3 = new Category { Name = "Chess" };
        context.Products.AddRange(
            new Product { Name = "Kayak", Price = 275, Category = c1, Suppliler = s1 },
            new Product { Name = "Jacket", Price = 235, Category = c1, Suppliler = s2 },
            new Product { Name = "Ball", Price = 215, Category = c2, Suppliler = s3 },
            new Product { Name = "Flag", Price = 295, Category = c2, Suppliler = s1 },
            new Product { Name = "Stadium", Price = 175, Category = c2, Suppliler = s2 },
            new Product { Name = "Cap", Price = 75, Category = c1, Suppliler = s3 },
            new Product { Name = "Chair", Price = 75, Category = c3, Suppliler = s1 },
            new Product { Name = "Board", Price = 175, Category = c3, Suppliler = s2 },
            new Product { Name = "King", Price = 375, Category = c3, Suppliler = s3 },
            new Product { Name = "Yallo", Price = 475, Category = c1, Suppliler = s1 }
        );
        context.SaveChanges();
    }
}
