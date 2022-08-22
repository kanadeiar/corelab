namespace SimpleConsole;

public class AnotherHybridLock : IDisposable
{
    private int _waiters = 0;
    private AutoResetEvent _waiterLock = new AutoResetEvent(false);
    private int _spinCount = 4000;
    private int _owningThreadId = 0, _recursion = 0;
    public void Enter()
    {
        var threadId = Thread.CurrentThread.ManagedThreadId;
        if (threadId == _owningThreadId) { _recursion++; return; }
        var spinwait = new SpinWait();
        for (int spinCount = 0; spinCount < _spinCount; spinCount++)
        {
            if (Interlocked.CompareExchange(ref _waiters, 1, 0) == 0) goto GotLock;
            spinwait.SpinOnce();
        }
        if (Interlocked.Increment(ref _waiters) > 1)
        {
            _waiterLock.WaitOne(); // Значительное падение производительности
        }
    GotLock:
        _owningThreadId = threadId;
        _recursion = 1;
    }
    public void Leave()
    {
        var threadId = Thread.CurrentThread.ManagedThreadId;
        if (threadId != _owningThreadId)
            throw new SynchronizationLockException("Lock not owned by calling thread");
        if (--_recursion > 0) return;
        _owningThreadId = 0;
        if (Interlocked.Decrement(ref _waiters) == 0)
            return;
        _waiterLock.Set(); // Значительное падение производительности
    }
    public void Dispose() => _waiterLock.Dispose();
}
