using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
    readonly IList<Inventory> cars = new List<Inventory>(); //наблюдаемая коллекция

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

class Inventory : INotifyPropertyChanged //наблюдаемая модель
{
    private int carId;
    public int CarId
    {
        get => carId;
        set
        {
            if (value == carId) return;
            carId = value;
            //передача названия свойства значение которого изменилось
            OnPropertyChanged(nameof(CarId));
        }
    }
    private string make;
    public string Make
    {
        get => make;
        set
        {
            if (value == make) return;
            make = value;
            OnPropertyChanged(nameof(Make));
        }
    }
    private string color;
    public string Color
    {
        get => color;
        set
        {
            if (value == color) return;
            color = value;
            OnPropertyChanged(nameof(Color));
        }
    }
    private string petName;
    public string PetName
    {
        get => petName;
        set
        {
            if (value == petName) return;
            petName = value;
            OnPropertyChanged(nameof(PetName));
        }
    }
    public event PropertyChangedEventHandler PropertyChanged;
    /// <summary> Вспомогательный метод индицирования события изменения свойства </summary>
    protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        //индицирование события со строкой, указывающей свойство, которое было изменено и нуждается в обновлении
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //обновление всех привязанных свойств объекта
        //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(string.Empty));
    }
}

