namespace Wpf;

/// <summary>
/// Локатор сервисов
/// </summary>
public class ServiceLocator
{
    public MainWindowViewModel MainWindowViewModel =>
        App.Services.GetRequiredService<MainWindowViewModel>();
}