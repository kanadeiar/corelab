using ConsoleApp1.Class;

namespace ConsoleApp1.Tests.Class.Down;

public class PrimePrinterTestsDown
{
    private StringWriter _writer;
    private PrimePrinter _printer;

    protected void makeTestData()
    {
        _writer = new StringWriter();
        Console.SetOut(_writer);
        _printer = new PrimePrinter();
    }

    protected void actPrint()
    {
        _printer.PrintPrimes();
    }

    protected void assertHeader()
    {
        var actuals = _writer.ToString();
        StringAssert.Contains("The First 1000 Prime Numbers --- Page 1", actuals);
    }

    protected void assertFirst()
    {
        var actuals = _writer.ToString();
        StringAssert.Contains("2       107       211       315", actuals);
    }

    protected void assertCentral()
    {
        var actuals = _writer.ToString();
        StringAssert.Contains("3       109       213       317", actuals);
        StringAssert.Contains("417       519       621       721", actuals);
        StringAssert.Contains("823       925      1027      1129", actuals);
    }

    protected void assertLast()
    {
        var actuals = _writer.ToString();
        StringAssert.Contains("1735      1835      1937      2039", actuals);
    }
}