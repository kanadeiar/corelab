namespace SimpleConsole;

public enum CoordinationStatus { AllDone, Timeout, Cancel };

public class AsyncCoordinator
{
    private int _opCount = 1; // Уменьшается на 1 методом AllBegun
    private int _statusReported = 0; // 0=false, 1=true
    private Action<CoordinationStatus>? _callback;
    private Timer? _timer;
    // ДО инициирования операции
    public void AboutToBegin(Int32 opsToAdd = 1)
    {
        Interlocked.Add(ref _opCount, opsToAdd);
    }
    // ПОСЛЕ обработки результата
    public void JustEnded()
    {
        if (Interlocked.Decrement(ref _opCount) == 0)
            ReportStatus(CoordinationStatus.AllDone);
    }
    // ПОСЛЕ инициирования ВСЕХ операций
    public void AllBegun(Action<CoordinationStatus> callback, int timeout = Timeout.Infinite)
    {
        _callback = callback;
        if (timeout != Timeout.Infinite)
            _timer = new Timer(TimeExpired, null, timeout, Timeout.Infinite);
        JustEnded();
    }
    private void TimeExpired(Object? o) => ReportStatus(CoordinationStatus.Timeout);
    public void Cancel() => ReportStatus(CoordinationStatus.Cancel);
    private void ReportStatus(CoordinationStatus status)
    {
        // Если состояние ни разу не передавалось, передать его, в противном случае оно игнорируется
        if (Interlocked.Exchange(ref _statusReported, 1) == 0)
            _callback?.Invoke(status);
    }
}
