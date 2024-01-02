using System.Numerics;

namespace ConsoleApp1.Tests.Fibonacci;

[TestFixture]
internal class FibonacciTests
{
    [TestCase(0, 0)]
    [TestCase(1, 1)]
    [TestCase(2, 1)]
    [TestCase(3, 2)]
    [TestCase(4, 3)]
    [TestCase(5, 5)]
    public void TestFibonacci(int value, int expected)
    {
        var fib = new Fibonacci();
        Assert.AreEqual(expected, fib.Fib(value));
    }
}

public class Fibonacci
{
    public T Fib<T>(T n)
        where T : INumber<T>
    {
        if (n == T.Zero) return T.Zero;
        if (n == T.One) return T.One;
        return Fib(n - T.One) + Fib(n - (T.One + T.One));
    }
}