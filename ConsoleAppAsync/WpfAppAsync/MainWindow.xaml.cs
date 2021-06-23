using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WpfAppAsync
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly List<string> s_Domains = new List<string>
        {
            "google.com",
            "bing.com",
            "oreilly.com",
            "simple-talk.com",
            "microsoft.com",
            "facebook.com",
            "twitter.com",
            "reddit.com",
            "baidu.com",
            "bbc.co.uk"
        };
        public MainWindow()
        {
            InitializeComponent();
        }

        private static Image MakeImageControl(byte[] bytes)
        {
            Image imageControl = new Image();
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = new MemoryStream(bytes);
            bitmapImage.EndInit();
            imageControl.Source = bitmapImage;
            imageControl.Width = 16;
            imageControl.Height = 16;
            return imageControl;
        }

        //private Task<bool> GetUserPermission() (PAGE 36)
        private bool GetUserPermission()
        {
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
            var res = MessageBox.Show("You're about to cause the client to lock up.", "Sure you want to?",
                MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            return res == MessageBoxResult.OK;

        }
        #region Methods Block (synchronous)

        private void AddAFaviconBlocks(string domain)
        {
            WebClient webClient = new WebClient();
            byte[] bytes = webClient.DownloadData("http://" + domain + "/favicon.ico");
            Image imageControl = MakeImageControl(bytes);
            m_WrapPanel.Children.Add(imageControl);
        }

        private void GetButtonBlocks_OnClick(object sender, RoutedEventArgs e)
        {
            if (!GetUserPermission())
                return;
            foreach (string domain in s_Domains)
            {
                AddAFaviconBlocks(domain);
            }
        }
        #endregion

        #region Event-based Asynchronous Pattern
        private void AddAFaviconEap(string domain)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadDataCompleted += OnWebDataDownloadCompleted;
            webClient.DownloadDataAsync(new Uri("http://" + domain + "/favicon.ico"));
        }

        private void OnWebDataDownloadCompleted(object sender, DownloadDataCompletedEventArgs args)
        {
            m_WrapPanel.Children.Add(MakeImageControl(args.Result));
        }

        private void GetButtonEap_OnClick(object sender, RoutedEventArgs e)
        {
            foreach (string domain in s_Domains)
            {
                AddAFaviconEap(domain);
            }
        } 
        #endregion

    }
}
