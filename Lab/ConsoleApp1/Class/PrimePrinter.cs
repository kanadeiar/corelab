namespace ConsoleApp1.Class;

public class PrimePrinter
{
    private const int COUNT_OF_PRIMES = 1000;
    private const int ROWS_PER_PAGE = 50;
    private const int COLUMNS_PER_PAGE = 4;

    public void PrintPrimes()
    {
        var generator = new PrimeGenerator(COUNT_OF_PRIMES);
        var primes = generator.Generate();

        var printer = new RowColumnPagePrinter(ROWS_PER_PAGE, COLUMNS_PER_PAGE, $"The First {COUNT_OF_PRIMES} Prime Numbers --- Page ");
        printer.Print(primes);
    }
}