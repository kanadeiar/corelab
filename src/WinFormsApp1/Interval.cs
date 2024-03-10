namespace WinFormsApp1;

public class Interval : IObservable
{
    private List<IObserver> _observers = new();
    private string _start = "0";
    private string _end = "0";
    private string _length = "0";

    public string Start
    {
        get => _start;
        set
        {
            if (_start == value) return;
            _start = value;
            CalculateLength();
            NotifyObservers();
        }
    }

    public string End
    {
        get => _end;
        set
        {
            if (_end == value) return;
            _end = value;
            CalculateLength();
            NotifyObservers();
        }
    }

    public string Length
    {
        get => _length;
        set
        {
            if (_length == value) return;
            _length = value;
            CalculateEnd();
            NotifyObservers();
        }
    }

    public void AddObserver(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in _observers)
            observer.Update(this, null);
    }

    public void CalculateLength()
    {
        try
        {
            var start = int.Parse(Start);
            var end = int.Parse(End);
            var length = end - start;
            Length = length.ToString();
        }
        catch
        {
            throw new ApplicationException("Некорректный формат числа");
        }
    }

    public void CalculateEnd()
    {
        try
        {
            var start = int.Parse(Start);
            var length = int.Parse(Length);
            var end = start + length;
            End = end.ToString();
        }
        catch 
        {
            throw new ApplicationException("Некорректный формат числа");
        }
    }
}