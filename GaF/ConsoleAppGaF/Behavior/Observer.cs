namespace ConsoleAppGaF.Behavior;

public interface IObserver
{
    void Update(ISubject subject);
}
public interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify();
}
public class Subject : ISubject
{
    public int State { get; set; } = 0;
    private List<IObserver> _observers = new List<IObserver>();
    public void Attach(IObserver observer)
    {
        Console.WriteLine("Attached");
        _observers.Add(observer);
    }
    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
        Console.WriteLine("Detached");
    }
    public void Notify()
    {
        Console.WriteLine("Subject - Notify");
        foreach (IObserver observer in _observers)
            observer.Update(this);
    }
    public void SomeBisinessLogic()
    {
        State++;
        Notify();
    }
}
class ConcreteObserverA : IObserver
{
    public void Update(ISubject subject)
    {
        if ((subject as Subject).State == 0 || (subject as Subject).State > 1)
        {
            Console.WriteLine("ConcreteObserverA: reacted to the event.");
        }
    }
}


