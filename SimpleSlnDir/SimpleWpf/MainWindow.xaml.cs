﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace SimpleWpf;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void myButton_Click(object s, RoutedEventArgs e)
    {
        this.Cursor = Cursors.Wait;
        Thread.Sleep(TimeSpan.FromSeconds(3));
        MessageBox.Show("Test");
        this.Cursor = null;
    }
}

