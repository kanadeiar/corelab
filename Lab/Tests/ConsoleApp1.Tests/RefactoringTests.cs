namespace ConsoleApp1.Tests;

public class RefactoringTests
{
    [Fact]
    public void TestRef()
    {
        var engineer = Employee.CreateWith("ConsoleApp1.Engineer");

        Assert.IsType<Engineer>(engineer);
    }
}








