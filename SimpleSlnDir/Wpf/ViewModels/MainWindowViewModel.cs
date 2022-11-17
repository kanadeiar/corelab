namespace Wpf.ViewModels;

public class MainWindowViewModel : Base.ViewModel
{
    private ISampleService _sampleService;

    private string _Text = "Текст пробный";
    public string Text
    {
        get => _Text;
        set => Set(ref _Text, value);
    }

    private string _Title = "Тестовое приложение - обобщенный хост";
    /// <summary> Заголовок </summary>
    public string Title
    {
        get => _Title;
        set => Set(ref _Title, value);
    }

    public MainWindowViewModel(ISampleService sampleService)
    {
        _sampleService = sampleService;

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

    private void Update()
    {
        Text = _sampleService.GetText();
    }
}