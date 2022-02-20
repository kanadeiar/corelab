namespace SportStore.Data;

public class StoreDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
    { }
}