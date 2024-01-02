namespace ConsoleApp1.Tests.Fibonacci;

[TestFixture]
internal class FibonacciTests2
{
    [Test]
    public void TestFibonacci()
    {
        Assert.AreEqual(0, Fib(0));
        Assert.AreEqual(1, Fib(1));
        Assert.AreEqual(1, Fib(2));
        Assert.AreEqual(2, Fib(3));
        Assert.AreEqual(3, Fib(4));
        Assert.AreEqual(5, Fib(5));
        Assert.AreEqual(8, Fib(6));
        Assert.AreEqual(13, Fib(7));
    }

    public int Fib(int n)
    {
        if (n == 0) return 0;
        if (n == 1) return 1;
        return Fib(n - 1) + (Fib(n - 2));
    }
}