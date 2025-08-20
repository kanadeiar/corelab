namespace MauiApp1.ViewModels;

public class MainPageViewModel : Base.ViewModel
{
    #region Стандартные свойства

    private string _title = "Опытное приложение";
    
    /// <summary> Название приложения </summary>
    public string Title
    {
        get => _title;
        set => Set(ref _title, value);
    }

    #endregion


}