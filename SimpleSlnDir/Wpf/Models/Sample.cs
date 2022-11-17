namespace Wpf.Models;

/// <summary>
/// Тестовая сущность
/// </summary>
public class Sample : Base.BaseModel
{
    private string _Name = string.Empty;
    /// <summary>
    /// Название
    /// </summary>
    public string Name
    {
        get => _Name;
        set => Set(ref _Name, value);
    }
}