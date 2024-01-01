namespace ConsoleApp1.XUnit;

public class TestSuite
{
    private List<TestCase> _tests;
    
    public TestSuite()
    {
        _tests = new List<TestCase>();
    }

    public void Add(TestCase test)
    {
        _tests.Add(test);
    }

    public TestResult Run(TestResult result)
    {
        foreach (var t in _tests)
        {
            t.Run(result);
        }
        return result;
    }
}