using Kanadeiar.Core.Async;

namespace SimpleConsole;

internal partial class Program
{
    private static async Task Main(string[] args)
    {
        Console.WriteLine("Начало программы");
        var asyncLock = new AsyncLock();

        await SimpleStatic.AddAsync(asyncLock);

        Console.WriteLine("Нажмите любую кнопку ...");
        var _ = Console.Read();
    }
}

static class SimpleStatic
{
    private static int _value;
    public static int Value => _value;
    public static async Task AddAsync(AsyncLock asyncLock)
    {
        await asyncLock.WaitAsync(LockMode.Shared); // Запросить общий доступ
        Console.WriteLine(_value); // Чтение из ресурса...
        asyncLock.Release(); // Снятие блокировки, чтобы ресурс стал доступен другим потокам
    }
}









