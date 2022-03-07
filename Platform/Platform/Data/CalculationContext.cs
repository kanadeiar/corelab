namespace Platform.Data;

public class CalculationContext : DbContext
{
    public DbSet<Calculation> Calculations { get; set; }
    public CalculationContext(DbContextOptions<CalculationContext> options) : base(options)
    { }
}
