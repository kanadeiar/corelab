using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Advanced.Data;

public class DataContext : DbContext
{
    public DbSet<Person> Persons { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
}
