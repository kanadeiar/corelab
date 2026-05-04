using NotepadWpfApp.Commands;
using System.Windows;
using System.Windows.Input;

namespace NotepadWpfApp.ViewModels;

public class MainWindowViewModel : Base.ViewModelBase
{
    public string Title
    {
        get;
        init => Set(ref field, value);
    } = "Опытное приложение 'Блокнот'.";

    public ICommand CloseAppCommand => field ??=
        new LambdaCommand(OnCloseAppCommandExecuted);
    private void OnCloseAppCommandExecuted(object? p)
    {
        Application.Current.Shutdown();
    }

    public ICommand AboutAppCommand => field ??=
        new LambdaCommand(OnAboutAppCommandExecuted);
    private void OnAboutAppCommandExecuted(object? p)
    {
        MessageBox.Show("Опытное приложение - блокнот.", "О программе ...");
    }
}
