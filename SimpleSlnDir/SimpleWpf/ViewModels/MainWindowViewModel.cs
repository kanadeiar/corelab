using System.Windows;
using System.Windows.Input;
using SimpleWpf.Commands;
using SimpleWpf.ViewModels.Base;
using SimpleWpf.Windows;

namespace SimpleWpf.ViewModels;

public class MainWindowViewModel : ViewModel
{
    #region Свойства

    private string _Title = "Заголовок простого приложения";
    public string Title
    {
        get => _Title;
        set => Set(ref _Title, value);
    }

    #endregion

    public MainWindowViewModel()
    {

    }

    #region Команды

    private ICommand _CloseAppCommand = null!;
    public ICommand CloseAppCommand => _CloseAppCommand ??=
        new RelayCommand(OnCloseAppCommandExecuted, CanCloseAppCommandExecute);
    private bool CanCloseAppCommandExecute(object p) => true;
    private void OnCloseAppCommandExecuted(object p)
    {
        Application.Current.Shutdown();
    }

    private ICommand _ShowAboutCommand = null!;
    public ICommand ShowAboutCommand => _ShowAboutCommand ??=
        new RelayCommand(OnShowAboutCommandExecuted, CanShowAboutCommandExecute);
    private bool CanShowAboutCommandExecute(object p) => true;
    private void OnShowAboutCommandExecuted(object p)
    {
        var form = new About();
        form.ShowDialog();
    }

    #endregion
}
