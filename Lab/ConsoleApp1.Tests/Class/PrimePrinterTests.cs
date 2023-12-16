using ConsoleApp1.Class;

namespace ConsoleApp1.Tests.Class;

[TestFixture]
public class PrimePrinterTests
{
    [Test]
    public void TestPrintPrimes()
    {
        var writer = new StringWriter();
        Console.SetOut(writer);
        var printer = new PrimePrinter();

        printer.PrintPrimes();

        var actuals = writer.ToString();
        StringAssert.Contains("The First 1000 Prime Numbers --- Page 1", actuals);
    }

    [Test]
    public void TestPrintPrimesFirstValues()
    {
        var writer = new StringWriter();
        Console.SetOut(writer);
        var printer = new PrimePrinter();

        printer.PrintPrimes();

        var actuals = writer.ToString();
        StringAssert.Contains("2       107       211       315", actuals);
    }

    [Test]
    public void TestPrintPrimesValues()
    {
        var writer = new StringWriter();
        Console.SetOut(writer);
        var printer = new PrimePrinter();

        printer.PrintPrimes();

        var actuals = writer.ToString();
        StringAssert.Contains("3       109       213       317", actuals);
        StringAssert.Contains("417       519       621       721", actuals);
        StringAssert.Contains("823       925      1027      1129", actuals);
    }

    [Test]
    public void TestPrintPrimesLastValues()
    {
        var writer = new StringWriter();
        Console.SetOut(writer);
        var printer = new PrimePrinter();

        printer.PrintPrimes();

        var actuals = writer.ToString();
        StringAssert.Contains("1735      1835      1937      2039", actuals);
    }
}