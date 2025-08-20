using MauiApp1.ViewModels;

namespace MauiApp1;

public partial class App : Application
{
    private static IServiceProvider? _provider;

    public static IServiceProvider Services => _provider ??= getServices()
        .BuildServiceProvider();

    private static IServiceCollection getServices()
    {
        var services = new ServiceCollection();
        initServices(services);
        return services;
    }

    private static void initServices(IServiceCollection services)
    {
        services.AddScoped<MainPageViewModel>();


    }

    public App()
    {
        InitializeComponent();


    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new AppShell());
    }
}