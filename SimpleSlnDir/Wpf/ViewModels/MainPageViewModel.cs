namespace Wpf.ViewModels;

/// <summary>
/// Вьюмодель главной страницы
/// </summary>
public class MainPageViewModel : Base.BaseViewModel
{
    private string _Text = "Просто текст";
    /// <summary> 
    /// Просто текст
    /// </summary>
    public string Text
    {
        get => _Text;
        set => Set(ref _Text, value);
    }

    public MainPageViewModel()
    {

    }
}