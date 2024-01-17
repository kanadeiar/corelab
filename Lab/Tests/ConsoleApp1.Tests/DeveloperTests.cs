using System.Collections;

namespace ConsoleApp1.Tests;

public class DeveloperTests
{
    [Fact]
    public void TestSimple()
    {
        Assert.True(true);
    }

    [Theory]
    [InlineData(true)]
    [InlineData("One")]
    public void Inline(object value)
    {
        Assert.NotNull(value);
    }

    [Theory, MemberData(nameof(GetTestData))]
    public void Method(int digital)
    {
        Assert.Equal(1, digital);
    }
    public static IEnumerable<object[]> GetTestData()
    {
        return new List<object[]>
        {
            new object[] { 1 }
        };
    }

    [Theory, MemberData(nameof(DataForTest))]
    public void GenericMethod(int one, int two)
    {
        Assert.Equal(one, two);
    }
    public static TheoryData<int, int> DataForTest = new TheoryData<int, int>
    {
        { 1, 1 }
    };

    [Theory, ClassData(typeof(TestData))]
    public void ClassStandard(int value)
    {
        Assert.Equal(1, value);
    }
    private class TestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 1 };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [Theory, MemberData(nameof(DataSource.TestData), 1, MemberType = typeof(DataSource))]
    public void ClassSource(int value)
    {
        Assert.Equal(1, value);
    }
    private static class DataSource
    {
        private static readonly List<object[]> _data = new List<object[]>
        {
            new object[] { 1 },
        };

        public static IEnumerable<object[]> TestData(int one)
        {
            return _data;
        }
    }

    [Theory, MemberData(nameof(TestData2), parameters: new object[] { new object[] { "1" } } )]
    public void TypesTestData(string s, bool expected)
    {
        Assert.Equal(expected, int.TryParse(s, out _));
    }
    public static TheoryData<string, bool> TestData2(object[] args)
    {
        return new TheoryData<string, bool>
        {
            { $"{args[0]}", true },
            { $"{args[0]}a", false },
        };
    }
}