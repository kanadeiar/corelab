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
        StringAssert.Contains("2       233       547       877", actuals);
    }

    protected void assertCentral()
    {
        var actuals = _writer.ToString();
        StringAssert.Contains("3       239       557       881", actuals);
        StringAssert.Contains("229       541       863      1223", actuals);
        StringAssert.Contains("2749      3187      3581      4001", actuals);
    }

    protected void assertLast()
    {
        var actuals = _writer.ToString();
        StringAssert.Contains("6571      6997      7499      7919", actuals);
    }
}