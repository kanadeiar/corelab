using System;
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
    readonly IList<Inventory> cars = new ObservableCollection<Inventory>(); //наблюдаемая коллекция

    public MainWindow()
    {
        InitializeComponent();
        cars.Add(new Inventory
        {
            CarId = 1,
            Make = "УАЗ",
            Color = "Белый",
            PetName = "Буханка",
        });
        cars.Add(new Inventory
        {
            CarId = 2,
            Make = "ЗАЗ",
            Color = "Коричневый",
            PetName = "Большая"
        });
        comboBoxCars.ItemsSource = cars;
    }
    private void ButtonChangeColor_OnClick(object sender, RoutedEventArgs e)
    {
        cars.First<Inventory>(x => x.CarId == ((Inventory)comboBoxCars.SelectedItem)?.CarId).Color = "Pink";
    }
    private void buttonAddCar_Click(object sender, RoutedEventArgs e)
    {
        var maxCount = cars?.Max(x => x.CarId) ?? 0;
        cars.Add(new Inventory
        {
            CarId = maxCount + 1,
            Color = "Желтый",
            Make = "ВАЗ",
            PetName = "Копейка",
        });
    }
}

