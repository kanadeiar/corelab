using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Avalonia.Controls;
using ReactiveUI;

namespace AvaloniaLab.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private string _data;
    public string Data
    {
        get => _data;
        set => this.RaiseAndSetIfChanged(ref _data, value);
    }

    public async Task Open()
    {
        var dialog = new OpenFileDialog();
        dialog.Filters.Add(new FileDialogFilter {Name = "Text", Extensions = {"txt"}});
        var result = await dialog.ShowAsync(new Window());
        if (result != null)
        {
            Data = File.ReadAllText(result.First());
        }
    }

    public async Task Save()
    {
        var dialog = new SaveFileDialog();
        dialog.Filters.Add(new FileDialogFilter { Name = "Text", Extensions = { "txt" } });
        var result = await dialog.ShowAsync(new Window());
        if (result != null)
        {
            File.WriteAllText(result, Data);
        }
    }
}