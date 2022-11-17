namespace Wpf;

public partial class App : Application
{
    private IHost _host;

    public App()
    {
        _host = new HostBuilder()
            .ConfigureAppConfiguration((context, builder) =>
            {
                builder.SetBasePath(context.HostingEnvironment.ContentRootPath);
                builder.AddJsonFile("appsettings.json", optional: false);
            })
            .ConfigureServices(InitServices)
            .ConfigureLogging(logging =>
            {
                logging.AddConsole();
            })
            .Build();
    }
    private static void InitServices(HostBuilderContext context, IServiceCollection services)
    {
        services.Configure<Settings>(context.Configuration);
        services.AddScoped<ISampleService, SampleService>();
        services.AddScoped<MainWindowViewModel>();
        services.AddScoped<MainWindow>();
    }
    private async void Application_Startup(object sender, StartupEventArgs e)
    {
        await _host.StartAsync();

        var mainWindow = _host.Services.GetService<MainWindow>();
        mainWindow?.Show();
    }
    private async void Application_Exit(object sender, ExitEventArgs e)
    {
        using (_host)
        {
            await _host.StopAsync(TimeSpan.FromSeconds(5));
        }
    }
}

