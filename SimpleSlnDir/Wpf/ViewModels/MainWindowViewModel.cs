namespace Wpf.ViewModels;

public class MainWindowViewModel : ViewModel
{
    private ISampleService _sampleService;

    private Sample _Sample = default!;
    public Sample Sample
    {
        get => _Sample;
        set => Set(ref _Sample, value);
    }

    private string _Title = "Приложение чтения файлов в бинарном виде";
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
        Sample = _sampleService.GetOne();
    }
}