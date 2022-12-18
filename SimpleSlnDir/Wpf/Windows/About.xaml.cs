namespace Wpf.Windows;

public partial class About : Window
{
    public About()
    {
        InitializeComponent();
    }

    private void OkButton_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }
}