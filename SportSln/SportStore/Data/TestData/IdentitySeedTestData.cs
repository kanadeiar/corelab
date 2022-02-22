namespace SportStore.Data.TestData;

public class IdentitySeedTestData : IIdentitySeedTestData
{
    public async Task SeedData(IServiceProvider provider, IConfiguration configuration)
    {
        provider = provider.CreateScope().ServiceProvider;
        var logger = provider.GetRequiredService<ILogger<AppIdentityDbContext>>();
        using var context = new AppIdentityDbContext(provider.GetRequiredService<DbContextOptions<AppIdentityDbContext>>());

        if (context == null || context.Users == null)
        {
            logger.LogError("Null IdentityContext");
            throw new ArgumentNullException("Null IdentityContext");
        }
        var pendingMigrations = await context.Database.GetPendingMigrationsAsync();
        if (pendingMigrations.Any())
        {
            logger.LogInformation($"Applying migrations: {string.Join(",", pendingMigrations)}");
            await context.Database.MigrateAsync();
        }
        if (context.Users.Any())
        {
            logger.LogInformation("IdentityContext database contains data - database init with test data is not required");
            return;
        }
        logger.LogInformation("Begin writing test data to database IdentityContext ...");

        var userManager = provider.GetRequiredService<UserManager<IdentityUser>>();

        if (await userManager.FindByNameAsync(TestData.Admin.Username) is null)
        {
            var adminUser = new IdentityUser
            {
                UserName = TestData.Admin.Username,
                Email = TestData.Admin.Email,
            };
            var result = await userManager.CreateAsync(adminUser, TestData.Admin.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description).ToArray();
                logger.LogError("New account of user {0} not created of problem: {1}", adminUser.UserName, string.Join(",", errors));
                throw new InvalidOperationException($"Error with create a user with username: {adminUser.UserName}, list errors: {string.Join(",", errors)}");
            }
        }

        logger.LogInformation("Complete writing test data to database IdentityContext ...");
    }
}