namespace SimpleConsole;

public sealed class SimpleHybridLock : IDisposable
{
    private int _waiters = 0;
    private AutoResetEvent _waiterLock = new AutoResetEvent(false);
    public void Enter()
    {
        if (Interlocked.Increment(ref _waiters) == 1)
            return;
        _waiterLock.WaitOne();
    }
    public void Leave()
    {
        if (Interlocked.Decrement(ref _waiters) == 0)
            return;
        _waiterLock.Set();
    }
    public void Dispose() => _waiterLock.Dispose();
}






