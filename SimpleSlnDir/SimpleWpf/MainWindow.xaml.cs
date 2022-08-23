using System;
using System.Threading.Tasks;
using System.Windows;

namespace SimpleWpf;

public partial class MainWindow : Window
{
    private readonly TaskScheduler m_syncContextTaskScheduler;
    public MainWindow()
    {
        InitializeComponent();
    }
    private void cmdCancel_Click(object sender, EventArgs e)
    {

    }
    private void cmdProcess_Click(object sender, EventArgs e)
    {
        this.Title = "Выполнение завершено";
    }
}

