using ConsoleApp1.Tests.Base;

namespace ConsoleApp1.Tests;

public class FibonacciTests : FibonacciTestBase
{
    [Theory]
    [MemberData(nameof(FibonacciDataSource))]
    public void FibonacciTest(int val, int expected)
    {
        Assert.Equal(expected, Fib(val));
    }

    public int Fib(int val)
    {
        if (val == 0) return 0;
        if (val == 1) return 1;
        return Fib(val - 1) + Fib(val - 2);
    }
}