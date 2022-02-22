namespace SportStore.Data.Interfaces;

public interface IIdentitySeedTestData
{
    public Task SeedData(IServiceProvider provider, IConfiguration configuration);
}