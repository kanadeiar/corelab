namespace ConsoleApp1.Tests;

[TestFixture]
public class ProgramTests
{
    [Test]
    public void MainTest()
    {
        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);

            Program.PrintPrimes();

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

            Program.PrintPrimes();

            var s = sw.ToString();
            StringAssert.Contains("2\r\n233\r\n547\r\n877", s);
        }
    }

    [Test]
    public void MainTestDigitals2()
    {
        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);

            Program.PrintPrimes();

            var s = sw.ToString();
            StringAssert.Contains("7\r\n251\r\n569\r\n887", s);
        }
    }
}