namespace WinFormsApp1.Base;

public interface IFormObserver
{
    void Update(IFormObservable observed, object? arg);
}