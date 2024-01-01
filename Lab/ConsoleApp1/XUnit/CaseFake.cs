using System.Text;

namespace ConsoleApp1.XUnit;

public class CaseFake : TestCase
{
    private StringBuilder _log { get; set; } = new StringBuilder();
    public string Log => _log.ToString();

    public bool IsBrokenSetUp { get; set; }

    public CaseFake(string name) : base(name)
    {
        
    }

    public override void SetUp()
    {
        if (IsBrokenSetUp)
        {
            throw new Exception();
        }
        _log.Append("SetUp ");
    }

    public override void TearDown()
    {
        _log.Append("TearDown ");
    }

    public void TestMethod()
    {
        _log.Append("TestMethod ");
    }

    public void TestBrokenMethod()
    {
        throw new Exception();
    }
}