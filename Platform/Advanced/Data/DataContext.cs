using Advanced.Models;
using Microsoft.EntityFrameworkCore;

namespace Advanced.Data;

public class DataContext : DbContext
{
    public DbSet<Person> Persons { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
}
