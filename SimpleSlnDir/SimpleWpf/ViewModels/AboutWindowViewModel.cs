using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using SimpleWpf.Commands;
using SimpleWpf.ViewModels.Base;


namespace SimpleWpf.ViewModels;

public class AboutWindowViewModel : ViewModel
{
    #region Свойства

    private string _Title = "О программе ...";
    public string Title
    {
        get => _Title;
        set => Set(ref _Title, value);
    }
    private string _Name = "Название приложения";
    public string Name
    {
        get => _Name;
        set => Set(ref _Name, value);
    }

    #endregion

    public AboutWindowViewModel()
    {

    }

    #region Команды

    private ICommand _CloseWindowCommand;
    public ICommand CloseWindowCommand => _CloseWindowCommand ??=
        new LambdaCommand(OnCloseWindowCommandExecuted, CanCloseWindowCommandExecute);
    private bool CanCloseWindowCommandExecute(object p) => true;
    private void OnCloseWindowCommandExecuted(object p)
    {
        var window = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
        window?.Close();
    }

    #endregion
}
