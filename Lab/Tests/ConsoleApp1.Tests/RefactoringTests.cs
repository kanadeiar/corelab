namespace ConsoleApp1.Tests;

public class RefactoringTests
{
    
}

public class EmployeeTests
{
    [Fact]
    public void TestEngineer()
    {
        var eng = new Engineer();

        var actual = eng.GetSalary(10);

        Assert.Equal(3000, actual);
    }

    [Fact]
    public void TestManager()
    {
        var eng = new Managet();

        var actual = eng.GetSalary(10);

        Assert.Equal(8000, actual);
    }

}









