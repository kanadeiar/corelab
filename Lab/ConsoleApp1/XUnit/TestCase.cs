namespace ConsoleApp1.XUnit;

public abstract class TestCase
{
    protected string _name;

    public TestCase(string name)
    {
        _name = name;
    }

    public abstract void SetUp();
    public abstract void TearDown();

    public TestResult Run(TestResult result)
    {
        try
        {
            SetUp();
            result.TestStarted();
            try
            {

                var method = GetType().GetMethod(_name);
                method.Invoke(this, Array.Empty<object>());
            }
            catch
            {
                result.TestFailed();
            }
            TearDown();
        }
        catch
        {
            result.TestFailed();
        }

        return result;
    }
}