namespace SimpleConsole;

class Simple
{
    public static async Task<int> Method(int value)
    {
        var result = value * 2;
        await Task.Delay(1_000);
        return result;
    }
}

