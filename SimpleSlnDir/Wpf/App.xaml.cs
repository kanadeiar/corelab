namespace Wpf;

public partial class App : Application
{
    private static IServiceProvider? __Services;
    private static IServiceCollection GetServices()
    {
        var services = new ServiceCollection();
        InitServices(services);
        return services;
    }

    /// <summary> 
    /// Сервисы 
    /// </summary>
    public static IServiceProvider Services => __Services ??= GetServices().BuildServiceProvider();
    private static void InitServices(IServiceCollection services)
    {
        services.AddScoped<ISampleService, SampleService>();

        services.AddScoped<MainWindowViewModel>();
    }
}

