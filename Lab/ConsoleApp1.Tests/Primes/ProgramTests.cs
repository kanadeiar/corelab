using ConsoleApp1.Primes;

namespace ConsoleApp1.Tests.Primes;

[TestFixture]
public class ProgramTests
{
    [Test]
    public void MainTest()
    {
        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);
            var printer = new PrimePrinter();
            printer.PrintPrimes();
            
            var s = sw.ToString();
            StringAssert.Contains("The first 1000 Prime Numbers --- Page 1", s);
        }
    }

    [Test]
    public void MainTestDigitals1()
    {
        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);
            var printer = new PrimePrinter();
            printer.PrintPrimes();

            var s = sw.ToString();
            StringAssert.Contains("2       233       547       877", s);
            StringAssert.Contains("11       257       571       907", s);
            StringAssert.Contains("229       541       863      1223", s);
        }
    }
}