namespace ConsoleApp1.Tests.Class;

[TestFixture]
public class PrimePrinterTests : Down.PrimePrinterTestsDown
{
    [SetUp]
    public void Init()
    {
        makeTestData();
    }

    [Test]
    public void TestPrintPrimes()
    {
        actPrint();

        assertHeader();
    }

    [Test]
    public void TestPrintPrimesFirstValues()
    {
        actPrint();

        assertFirst();
    }

    [Test]
    public void TestPrintPrimesValues()
    {
        actPrint();

        assertCentral();
    }

    [Test]
    public void TestPrintPrimesLastValues()
    {
        actPrint();

        assertLast();
    }
}