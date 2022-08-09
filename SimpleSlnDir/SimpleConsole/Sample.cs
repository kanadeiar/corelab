namespace SimpleConsole;

public class Sample
{
    public string Name { get; set; }
    public void Test(string name)
    {
        ArgumentNullException.ThrowIfNull(name);
        // код
    }
}


