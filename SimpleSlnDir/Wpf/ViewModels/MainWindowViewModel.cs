namespace Wpf.ViewModels;

/// <summary>
/// Вьюмодель главного окна
/// </summary>
public class MainWindowViewModel : Base.BaseViewModel
{
    private ITextService _textService;

    private string _Text = string.Empty;
    /// <summary> 
    /// Просто текст
    /// </summary>
    public string Text
    {
        get => _Text;
        set => Set(ref _Text, value);
    }

    private string _Title = "Тестовое приложение - обобщенный хост";
    /// <summary> 
    /// Заголовок 
    /// </summary>
    public string Title
    {
        get => _Title;
        set => Set(ref _Title, value);
    }

    public MainWindowViewModel(ITextService textService)
    {
        _textService = textService;

        Update();
    }

    private ICommand? _CloseAppCommand;
    /// <summary> 
    /// Закрыть приложение 
    /// </summary>
    public ICommand CloseAppCommand => _CloseAppCommand ??=
        new LambdaCommand(OnCloseAppCommandExecuted, CanCloseAppCommandExecute);
    private bool CanCloseAppCommandExecute(object p) => true;
    private void OnCloseAppCommandExecuted(object p)
    {
        Application.Current.Shutdown();
    }

    private ICommand? _ShowAboutCommand;
    /// <summary> 
    /// Открыть окно о программе 
    /// </summary>
    public ICommand ShowAboutCommand => _ShowAboutCommand ??=
        new LambdaCommand(OnShowAboutCommandExecuted, CanShowAboutCommandExecute);
    private bool CanShowAboutCommandExecute(object p) => true;
    private void OnShowAboutCommandExecuted(object p)
    {
        var form = new About();
        form.ShowDialog();
    }

    private void Update()
    {
        Text = _textService.GetText();
    }
}