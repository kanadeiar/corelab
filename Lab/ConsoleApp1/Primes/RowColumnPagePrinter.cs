namespace ConsoleApp1.Primes;

public class RowColumnPagePrinter
{
    private readonly int _rowsPerPage;
    private readonly int _columnsPerPage;
    private int _numbersPerPage;
    private readonly string _message;

    public RowColumnPagePrinter(int rowsPerPage, int columnsPerPage, string message)
    {
        _rowsPerPage = rowsPerPage;
        _columnsPerPage = columnsPerPage;
        _message = message;
        _numbersPerPage = _rowsPerPage * _columnsPerPage;
    }

    public void Print(IEnumerable<int> primes)
    {
        var localPrimes = primes.ToArray();
        var pageNumber = 1;
        for (int firstIndexOnPage = 0; firstIndexOnPage < localPrimes.Count(); firstIndexOnPage += _numbersPerPage)
        {
            var lastIndexOnPage = Math.Min(firstIndexOnPage + _numbersPerPage - 1, localPrimes.Length - 1);
            PrintPageHeader(_message, pageNumber);
            PrintPage(firstIndexOnPage, lastIndexOnPage, localPrimes);
            Console.WriteLine();
            pageNumber++;
        }
    }

    private void PrintPageHeader(string pageHeader, int pageNumber)
    {
        Console.WriteLine(pageHeader + " --- Page " + pageNumber);
        Console.WriteLine();
    }

    private void PrintPage(int firstIndexOnPage, int lastIndexOnPage, int[] primes)
    {
        var firstIndexOfLastRowOnPage = firstIndexOnPage + _rowsPerPage - 1;
        for (int firstIndexInRow = firstIndexOnPage; firstIndexInRow <= firstIndexOfLastRowOnPage; firstIndexInRow++)
        {
            PrintRow(firstIndexInRow, lastIndexOnPage, primes);
            Console.WriteLine();
        }
    }

    private void PrintRow(int firstIndexInRow, int lastIndexOnPage, int[] primes)
    {
        for (int column = 0; column < _columnsPerPage; column++)
        {
            var index = firstIndexInRow + column * _rowsPerPage;
            if (index <= lastIndexOnPage)
            {
                Console.Write("{0,10}", primes[index]);
            }
        }
    }
}