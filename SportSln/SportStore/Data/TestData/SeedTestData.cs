namespace SportStore.Data.TestData;

public class SeedTestData : ISeedTestData
{
    public async Task SeedData(IServiceProvider provider, IConfiguration configuration)
    {
        provider = provider.CreateScope().ServiceProvider;
        var logger = provider.GetRequiredService<ILogger<StoreDbContext>>();
        using var context = new StoreDbContext(provider.GetRequiredService<DbContextOptions<StoreDbContext>>());

        if (context == null || context.Products == null)
        {
            logger.LogError("Null Context");
            throw new ArgumentNullException("Null Context");
        }
        var pendingMigrations = await context.Database.GetPendingMigrationsAsync();
        if (pendingMigrations.Any())
        {
            logger.LogInformation($"Applying migrations: {string.Join(",", pendingMigrations)}");
            await context.Database.MigrateAsync();
        }
        if (context.Products.Any())
        {
            logger.LogInformation("Context database contains data - database init with test data is not required");
        }
        logger.LogInformation("Begin writing test data to database Context ...");

        context.Products.AddRange(
            new Product
            {
                Name = "Test1",
                Description = "A test product number 1",
                Price = 100,
                Category = "Testsports",
            },
            new Product
            {
                Name = "Kayak",
                Description = "A boat for one person",
                Price = 272,
                Category = "Watersports",
            },
            new Product
            {
                Name = "Lifejacket",
                Description = "Protective and fashionable",
                Price = 45.56m,
                Category = "Watersports",
            },
            new Product
            {
                Name = "Soccer Ball",
                Description = "FIFA size and weight",
                Price = 19.5m,
                Category = "Soccer",
            },
            new Product
            {
                Name = "Corner Flags",
                Description = "Simple flags",
                Price = 79500,
                Category = "Soccer",
            },
            new Product
            {
                Name = "Stadium",
                Description = "Flat-packet stadium",
                Price = 34.95m,
                Category = "Soccer",
            },
            new Product
            {
                Name = "Thinking Cap",
                Description = "Improve brain efficiency by 100%",
                Price = 16,
                Category = "Chess",
            },
            new Product
            {
                Name = "Unsteady Chair",
                Description = "Secretly give your opponent a disadvantage",
                Price = 29.95m,
                Category = "Chess",
            },
            new Product
            {
                Name = "Human Chess Board",
                Description = "A fun game for the family",
                Price = 75,
                Category = "Chess",
            },
            new Product
            {
                Name = "Bling-Bling King",
                Description = "Gold-plated, diamond-studded King",
                Price = 1200,
                Category = "Chess",
            }
        );
        await context.SaveChangesAsync();

        logger.LogInformation("Complete writing test data to database Context ...");
    }
}