namespace ConsoleApp1.Primes;

public class PrimePrinter
{
    public const int NUMBER_OF_PRIMES = 1000;
    private const int ROWS_PER_PAGE = 50;
    private const int COLUMNS_PER_PAGE = 4;

    public void PrintPrimes()
    {
        var primes = PrimeGenerator.Generate(NUMBER_OF_PRIMES).ToArray();
        var tablePrinter = new RowColumnPagePrinter(ROWS_PER_PAGE, COLUMNS_PER_PAGE, "The first " + NUMBER_OF_PRIMES + " Prime Numbers");
        tablePrinter.Print(primes);
    }
}