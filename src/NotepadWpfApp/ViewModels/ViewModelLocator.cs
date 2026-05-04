using Microsoft.Extensions.DependencyInjection;

namespace NotepadWpfApp.ViewModels;

public class ViewModelLocator
{
    public static MainWindowViewModel MainWindowViewModel => App.Provider.GetRequiredService<MainWindowViewModel>();
}
