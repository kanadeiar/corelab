namespace ConsoleApp1;

public class RowColumnPagePrinter(int rowsPerPage, int columnsPerPage, string message)
{
    public void Print(IEnumerable<int> primes)
    {
        var localPrimes = primes.ToArray();
        int PAGENUMBER;
        int PAGEOFFSET;
        int ROWOFFSET;
        int C;
        PAGENUMBER = 1;
        PAGEOFFSET = 1;
        while (PAGEOFFSET <= Program.NUMBER_OF_PRIMES)
        {
            Console.WriteLine(message + " --- Page " + PAGENUMBER);
            Console.WriteLine();
            for (ROWOFFSET = PAGEOFFSET; ROWOFFSET < PAGEOFFSET + rowsPerPage; ROWOFFSET++)
            {
                for (C = 0; C < columnsPerPage; C++)
                {
                    if (ROWOFFSET + C * rowsPerPage <= Program.NUMBER_OF_PRIMES)
                    {
                        Console.WriteLine($"{localPrimes[ROWOFFSET + C * rowsPerPage]}");
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine("\t");
            PAGENUMBER++;
            PAGEOFFSET += rowsPerPage * columnsPerPage;
        }
    }
}