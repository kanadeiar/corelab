using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace SimpleWpf;

public partial class MainWindow : Window
{
    private readonly TaskScheduler _syncContextTaskScheduler;
    private CancellationTokenSource? _cancelToken = null;
    public MainWindow()
    {
        InitializeComponent();
    }

    private void cmdCancel_Click(object sender, EventArgs e)
    {
        _cancelToken?.Cancel();
    }
    private async void cmdProcess_Click(object sender, EventArgs e)
    {
        _cancelToken = new CancellationTokenSource();
        var basePath = Directory.GetCurrentDirectory();
        var pictureDirectory = Path.Combine(basePath, "TestPictures");
        var outputDirectory = Path.Combine(basePath, "ModifiedPictures");
        if (Directory.Exists(outputDirectory))
        {
            Directory.Delete(outputDirectory, true);
        }
        Directory.CreateDirectory(outputDirectory);
        string[] files = Directory.GetFiles(pictureDirectory, "*.jpg", SearchOption.AllDirectories);
        try
        {
            foreach (var file in files)
            {
                try
                {
                    await ProcessFile(file, outputDirectory, _cancelToken.Token);
                }
                catch (OperationCanceledException)
                {
                    Dispatcher?.Invoke(() =>
                    {
                        this.Title = "Отменено";
                    });
                }
            }
            Dispatcher?.Invoke(() =>
            {
                if (!_cancelToken.IsCancellationRequested)
                {
                    this.Title = "Выполнение завершено";
                }
            });
        }
        catch (OperationCanceledException)
        {
            Dispatcher?.Invoke(() =>
            {
                this.Title = "Отменено";
            });
        }
        catch (Exception ex)
        {
            Dispatcher?.Invoke(() =>
            {
                this.Title = ex.Message;
            });
            throw;
        }
        _cancelToken = null;
    }

    private async Task ProcessFile(string currentFile, string outputDirectory, CancellationToken token)
    {
        var filename = Path.GetFileName(currentFile);
        using (var bitmap = new Bitmap(currentFile))
        {
            try
            {
                await Task.Run(() =>
                {
                    Dispatcher?.Invoke(() =>
                    {
                        this.Title = $"Обработка {filename}";
                    });
                    bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    bitmap.Save(Path.Combine(outputDirectory, filename));
                }, token);
            }
            catch (OperationCanceledException)
            {
                Dispatcher?.Invoke(() =>
                {
                    this.Title = "Отменено";
                });
            }
        }
    }
}

