namespace SimpleConsole;

public class Sample
{
    public string Name { get; set; } = default!;
    public void Test(string name)
    {
        ArgumentNullException.ThrowIfNull(name);
        // код
    }
}


