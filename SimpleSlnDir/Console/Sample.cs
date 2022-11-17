using System.Diagnostics;

public static class Sample
{
    public unsafe static T Add<T>(T one, T two) where T : INumber<T>
    {
        return one + two;
    }
    public unsafe static T Sub<T>(T one, T two) where T : INumber<T>
    {
        return one - two;
    }
}

