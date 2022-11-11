using System.Diagnostics;

public static class Sample
{
    public static T Add<T>(T one, T two) where T : INumber<T>
    {
        return one + two;
    }
}

