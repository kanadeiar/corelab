namespace MauiApp1.ViewModels;

public class ViewModelLocator
{
    public MainPageViewModel MainPageViewModel => App.Services
        .GetRequiredService<MainPageViewModel>();
}