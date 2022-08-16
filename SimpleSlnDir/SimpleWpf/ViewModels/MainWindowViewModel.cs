using System.Threading;
using System.Threading.Tasks;
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

    private CancellationTokenSource _cts;
    private readonly TaskScheduler _syncContextTaskScheduler;
    private string _Text;
    public string Text
    {
        get => _Text;
        set => Set(ref _Text, value);
    }

    #endregion

    public MainWindowViewModel()
    {
        _syncContextTaskScheduler =
        TaskScheduler.FromCurrentSynchronizationContext();
        Text = "Тестирование";
    }

    #region Команды

    private ICommand _TestCommand = null;
    public ICommand TestCommand => _TestCommand ??=
        new RelayCommand(OnTestCommandExecuted, CanTestCommandExecute);
    private bool CanTestCommandExecute(object p) => true;
    private void OnTestCommandExecuted(object p)
    {
        if (_cts != null)
        { // Операция начата, отменяем ее
            _cts.Cancel();
            _cts = null;
        }
        else
        { // Операция не начата, начинаем ее
            Text = "Operation running";
            _cts = new CancellationTokenSource();
            Task<int> t = Task.Run(() => Sum(20000, _cts.Token), _cts.Token);
            t.ContinueWith(task => Text = "Result: " + task.Result,
            CancellationToken.None,
            TaskContinuationOptions.OnlyOnRanToCompletion,
            _syncContextTaskScheduler);
            t.ContinueWith(task => Text = "Operation canceled",
            CancellationToken.None, TaskContinuationOptions.OnlyOnCanceled,
            _syncContextTaskScheduler);
            t.ContinueWith(task => Text = "Operation faulted",
            CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted,
            _syncContextTaskScheduler);

        }
    }
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

    public int Sum(int value, CancellationToken token)
    {
        var sum = 0;
        for (int i = 0; i < value; i++)
        {
            token.ThrowIfCancellationRequested();
            sum += i;
        }
        return sum;
    }
}
