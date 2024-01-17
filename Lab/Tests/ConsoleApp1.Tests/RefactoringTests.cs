namespace ConsoleApp1.Tests;

public class RefactoringTests
{
    [Fact]
    public void TestCalculate()
    {
        var reff = new Refactoring();

        var actual = reff.Calculate();

        Assert.Equal(150.0, actual);
    }
}








