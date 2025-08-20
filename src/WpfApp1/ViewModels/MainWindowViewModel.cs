using System.Windows;
using System.Windows.Input;
using WpfApp1.Commands;

namespace WpfApp1.ViewModels;

public class MainWindowViewModel : Base.ViewModelBase
{
    public string Title
    {
        get;
        init => Set(ref field, value);
    } = "Опытно-экспериментальное настольное приложение";

    ///// <summary>
    ///// Закрыть приложение
    ///// </summary>
    public ICommand CloseAppCommand => field ??=
        new LambdaCommand(OnCloseAppCommandExecuted, CanCloseAppCommandExecute);
    private bool CanCloseAppCommandExecute(object? p) => true;
    private void OnCloseAppCommandExecuted(object? p)
    {
        Application.Current.Shutdown();
    }
}