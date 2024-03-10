namespace WinFormsApp1;

public interface IObserver
{
    void Update(IObservable observed, object arg);
}