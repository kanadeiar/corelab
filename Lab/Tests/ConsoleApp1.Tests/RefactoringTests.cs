namespace ConsoleApp1.Tests;

public class RefactoringTests
{
    [Fact]
    public void TestType()
    {

    }

    [Fact]
    public void TestCalc()
    {
        var ref1 = new Refactoring();

        var actual = ref1.Calc(new DateTime(1988, 7, 1));

        Assert.Equal(1 * 232 + 1988, actual);
    }

    [Fact]
    public void TestCalc_WhenNotRange()
    {
        var ref1 = new Refactoring();

        var actual = ref1.Calc(new DateTime(1988, 3, 1));

        Assert.Equal(3 * 60, actual);
    }
}




