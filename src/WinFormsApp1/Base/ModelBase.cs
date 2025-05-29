namespace WinFormsApp1.Base;

public abstract class ModelBase : IFormObservable
{
    private List<IFormObserver> _observers = new();

    public void AddObserver(IFormObserver formObserver)
    {
        _observers.Add(formObserver);
    }

    public void RemoveObserver(IFormObserver formObserver)
    {
        _observers.Remove(formObserver);
    }

    public void NotifyObservers()
    {
        foreach (var observer in _observers)
            observer.Update(this, null);
    }

    protected bool Set<T>(ref T field, T value)
    {
        if (value is null || value.Equals(field)) return false;

        field = value;
        NotifyObservers();
        return true;
    }
}