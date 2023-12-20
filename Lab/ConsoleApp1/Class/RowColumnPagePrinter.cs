namespace ConsoleApp1.Class;

public class RowColumnPagePrinter
{
    private readonly int _rowsPerPage;
    private readonly int _columnsPerPage;
    private readonly int _numbersPerPage;
    private readonly string _pageHeader;

    public RowColumnPagePrinter(int rowsPerPage, int columnsPerPage, string pageHeader)
    {
        _rowsPerPage = rowsPerPage;
        _columnsPerPage = columnsPerPage;
        _numbersPerPage = _rowsPerPage * _columnsPerPage;
        _pageHeader = pageHeader;
    }

    public void Print(IEnumerable<int> data)
    {
        var localData = data.ToArray();
        var count = localData.Length;
        int PAGENUMBER = 1;
        int PAGEOFFSET = 1;
        int ROWOFFSET;
        int C;
        while (PAGEOFFSET <= count)
        {
            Console.WriteLine(_pageHeader + PAGENUMBER);
            Console.WriteLine();
            for (ROWOFFSET = PAGEOFFSET; ROWOFFSET < PAGEOFFSET + _rowsPerPage; ROWOFFSET++)
            {
                for (C = 0; C < _columnsPerPage; C++)
                {
                    if (ROWOFFSET + C * _rowsPerPage < count)
                    {
                        Console.Write("{0,10}", localData[ROWOFFSET + C * _rowsPerPage]);
                    }
                }
                Console.WriteLine();
            }
            PAGENUMBER++;
            PAGEOFFSET += _numbersPerPage;
        }
    }
}