using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Text;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CancellationTokenSource _source;

        public MainWindow()
        {
            InitializeComponent();
            _source = new CancellationTokenSource();

        }

        private async void ButtonGo_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                ListViewResult.Items.Clear();
                var urls = new[] { @"https://ya.ru", @"https://mail.ru/", @"https://www.google.com/", @"https://www.youtube.com/", };
                var progress = new Progress<float>(Handler);
                var pages = await GetPages(urls, _source.Token, progress);
                foreach (var p in pages)
                {
                    ListViewResult.Items.Add("length: " + p.Length);
                }
            }
            catch (TaskCanceledException)
            {}
            catch (Exception exception)
            {
                MessageBox.Show("Ошибка:" + exception);
            }
        }

        private void Handler(float value)
        {
            ProgressBarOperation.Value = value;
        }

        static async Task<IEnumerable<string>> GetPages(IEnumerable<string> urls, CancellationToken token = default,
            IProgress<float>? progress = default)
        {
            var pages = new List<string>();
            var current = 0.0f;
            var step = 100.0f / urls.Count();
            var us = urls as string[] ?? urls.ToArray();
            foreach (var url in us.ToArray())
            {
                progress?.Report(current += step);
                token.ThrowIfCancellationRequested();
                var task = GetPage(url, token);
                pages.Add(await task);
            }
            return pages;
        }

        static async Task<string> GetPage(string url, CancellationToken token = default)
        {
            var client = new HttpClient();
            var page = await client.GetStringAsync(url, token);
            return page;
        }

        private void ButtonCancel_OnClick(object sender, RoutedEventArgs e)
        {
            _source.Cancel();
        }
    }
}
