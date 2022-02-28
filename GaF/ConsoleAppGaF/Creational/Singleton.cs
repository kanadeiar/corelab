namespace ConsoleAppGaF.Creational;

public sealed class Singleton
{
    private Singleton() { }
    private static Singleton _instance;
    public static Singleton GetInstance() => _instance ??= new Singleton();
}
