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
}

