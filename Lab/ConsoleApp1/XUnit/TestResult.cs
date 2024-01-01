namespace ConsoleApp1.XUnit;

public class TestResult
{
    public int RunCount { get; set; }
    public int ErrorCount { get; set; }

    public TestResult()
    {
        
    }

    public void TestStarted()
    {
        RunCount++;
    }

    public string Summary()
    {
        return $"{RunCount} run, {ErrorCount} failed";
    }

    public void TestFailed()
    {
        ErrorCount++;
    }
}