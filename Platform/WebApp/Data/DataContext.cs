// dotnet ef migrations add init

using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Data;

public class DataContext : DbContext
{
    public DbSet<Category> Categiries { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    { }
}
