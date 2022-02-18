namespace SportStore.Data.Interfaces;

public interface ISeedTestData
{
    public Task SeedData(IServiceProvider provider, IConfiguration configuration);
}