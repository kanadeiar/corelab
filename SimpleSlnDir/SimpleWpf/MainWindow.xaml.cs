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
    private CancellationTokenSource _cancelToken = new CancellationTokenSource();
    public MainWindow()
    {
        InitializeComponent();
    }
    private void cmdCancel_Click(object sender, EventArgs e)
    {
        _cancelToken.Cancel();
    }
    private void cmdProcess_Click(object sender, EventArgs e)
    {
        Task.Factory.StartNew(() => ProcessFiles());
        this.Title = "Выполнение завершено";
    }
    private void ProcessFiles()
    {
        var parOpts = new ParallelOptions();
        parOpts.CancellationToken = _cancelToken.Token;
        parOpts.MaxDegreeOfParallelism = System.Environment.ProcessorCount;
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
            Parallel.ForEach(files, parOpts, currentFile =>
            {
                parOpts.CancellationToken.ThrowIfCancellationRequested();
                var filename = Path.GetFileName(currentFile);
                Dispatcher?.Invoke(() =>
                {
                    this.Title = $"Обработка {filename} в потоке {Thread.CurrentThread.ManagedThreadId}";
                });
                using (var bitmap = new Bitmap(currentFile))
                {
                    bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    bitmap.Save(Path.Combine(outputDirectory, filename));
                }
            });
            Dispatcher?.Invoke(() => this.Title = "Готово!");
        }
        catch (OperationCanceledException ex)
        {
            Dispatcher?.Invoke(() => this.Title = ex.Message);
        }


    }
}

