namespace WinFormsApp1.Base;

public interface IFormObservable
{
    void AddObserver(IFormObserver formObserver);
    void RemoveObserver(IFormObserver formObserver);
    void NotifyObservers();
}