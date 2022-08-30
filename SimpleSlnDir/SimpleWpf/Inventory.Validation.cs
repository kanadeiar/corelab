using System.ComponentModel;

namespace SimpleWpf;

partial class Inventory : IDataErrorInfo
{
    private string _error;
    //индексатор валидации
    public string this[string columnName]
    {
        get
        {
            switch (columnName)
            {
                case nameof(CarId):
                    break;
                case nameof(Make):
                    if (Make == "Чайка")
                    {
                        return "Слишком старая";
                    }
                    return CheckMakeAndColor();
                case nameof(Color):
                    return CheckMakeAndColor();
                case nameof(PetName):
                    break;
            }
            return string.Empty;
        }
    }
    private string CheckMakeAndColor()
    {
        if (Make == "Копейка" && Color == "Беж")
        {
            return $"{Make} не может быть цвета {Color}";
        }
        return string.Empty;
    }
    public string Error => _error;
}