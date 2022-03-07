namespace Platform.Data;

public class SeedData
{
    private readonly IServiceProvider _scope;
    private readonly ILogger<SeedData> _logger;
    private static readonly Dictionary<int, long> data = new Dictionary<int, long>() 
    {
        {1, 1}, {2, 3}, {3, 6}, {4, 10}, {5, 15}, {6, 21}, {7, 28}, {8, 36}, {9, 45}, {10, 55}
    };
    public SeedData(IServiceProvider provider, ILogger<SeedData> logger)
    {
        _logger = logger;
        _scope = provider.CreateScope().ServiceProvider;
    }
    public void SeedDatabase()
    {
        using var context = new CalculationContext(_scope.GetRequiredService<DbContextOptions<CalculationContext>>());
        context.Database.Migrate();
        if (context.Calculations.Any())
        {
            _logger.LogInformation("Database not need seed");
            return;
        }
        else
        {
            context.AddRange(data.Select(x => new Calculation { Count = x.Key, Result = x.Value }));
            context.SaveChanges();
            _logger.LogInformation("Database seeded");
        }
    }

}
