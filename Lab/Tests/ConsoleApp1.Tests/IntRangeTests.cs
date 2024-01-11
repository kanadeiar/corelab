namespace ConsoleApp1.Tests;

public class IntRangeTests
{
    [Fact]
    public void TestLow()
    {
        var range = new IntRange(1, 10);

        range.Low = 10;
        var actual = range.Low;

        Assert.Equal(10, actual);
    }

    [Fact]
    public void TestHigh()
    {
        var range = new IntRange(1, 10);

        range.High = 20;
        var actual = range.High;

        Assert.Equal(20, actual);
    }

    [Fact]
    public void TestIncludes()
    {
        var range = new IntRange(1, 10);
        
        Assert.True(range.Includes(5));
        Assert.False(range.Includes(0));
    }

    [Fact]
    public void TestGrow()
    {
        var range = new IntRange(1, 10);

        range.Grow(2);

        Assert.Equal(10 * 2, range.High);
    }
}

public class CappedRangeTests
{
    [Fact]
    public void TestCap()
    {
        var range = new CappedRange(1, 10, 5);

        range.Cap = 7;
        
        Assert.Equal(1, range.Low);
        Assert.Equal(7, range.Cap);
        Assert.Equal(7, range.High);
    }
}