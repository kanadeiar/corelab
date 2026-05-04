using Microsoft.Extensions.DependencyInjection;
using NotepadWpfApp.ViewModels;
using System.Windows;

namespace NotepadWpfApp;

public partial class App : Application
{
    public static IServiceProvider Provider => field ??= GetServices()
        .BuildServiceProvider();

    private static IServiceCollection GetServices()
    {
        var services = new ServiceCollection();
        InitServices(services);
        return services;
    }

    private static void InitServices(IServiceCollection services)
    {
        services.AddScoped<MainWindowViewModel>();


    }
}
