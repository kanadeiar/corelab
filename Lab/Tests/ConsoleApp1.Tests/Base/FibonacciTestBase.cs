namespace ConsoleApp1.Tests.Base;

public class FibonacciTestBase
{
    public static TheoryData<int, int> FibonacciDataSource()
    {
        var data = new TheoryData<int, int>
        {
            { 0, 0 },
            { 1, 1 },
            { 2, 1 },
            { 3, 2 },
            { 4, 3 },
            { 5, 5 },
        };
        return data;
    }
}