using Microsoft.Extensions.DependencyInjection;

namespace WpfApp1.ViewModels;

public class ViewModelLocator
{
    public static MainWindowViewModel MainWindowViewModel => App.Provider.GetRequiredService<MainWindowViewModel>();
}