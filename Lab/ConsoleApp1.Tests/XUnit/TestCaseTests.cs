using ConsoleApp1.XUnit;
using NUnit.Framework.Internal;
using TestResult = ConsoleApp1.XUnit.TestResult;
using TestSuite = ConsoleApp1.XUnit.TestSuite;

namespace ConsoleApp1.Tests.XUnit;

[TestFixture]
public class TestCaseTests
{
    private TestResult _result;
    private CaseFake _test;

    [SetUp]
    public void Setup()
    {
        _result = new TestResult();
    }

    [Test]
    public void TestTemplateMethod()
    {
        _test = new CaseFake("TestMethod");
        _test.Run(_result);
        Assert.AreEqual("SetUp TestMethod TearDown ", _test.Log.ToString());
    }

    [Test]
    public void TestResult()
    {
        _test = new CaseFake("TestMethod");
        var result = _test.Run(_result);
        Assert.AreEqual("1 run, 0 failed", result.Summary());
    }

    [Test]
    public void TestFailedResult()
    {
        _test = new CaseFake("TestBrokenMethod");
        var result = _test.Run(_result);
        Assert.AreEqual("1 run, 1 failed", result.Summary());
    }

    [Test]
    public void TestSetUpFailed()
    {
        _test = new CaseFake("TestBrokenMethod");
        _test.IsBrokenSetUp = true;
        var result = _test.Run(_result);
        Assert.AreEqual("0 run, 1 failed", result.Summary());
    }

    [Test]
    public void TestFailedResultFormatting()
    {
        var result = new TestResult();
        result.TestStarted();
        result.TestFailed();
        Assert.AreEqual("1 run, 1 failed", result.Summary());
    }

    [Test]
    public void TestMySuite()
    {
        var suite = new TestSuite();
        suite.Add(new CaseFake("TestMethod"));
        suite.Add(new CaseFake("TestBrokenMethod"));
        suite.Run(_result);
        Assert.AreEqual("2 run, 1 failed", _result.Summary());
    }
}