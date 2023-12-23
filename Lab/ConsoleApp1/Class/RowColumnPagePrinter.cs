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
        var count = localData.Length - 1;
        int pageNumber = 1;
        for (var firstIndexOnPage = 1; firstIndexOnPage <= count; firstIndexOnPage++)
        {
            printPage(firstIndexOnPage, count, pageNumber, localData);
            pageNumber++;
        }
    }

    private void printPage(int firstIndexOnPage, int count, int pageNumber, int[] localData)
    {
        var lastIndexOnPage = Math.Min(firstIndexOnPage + _numbersPerPage, count + 1);
        printPageHeader(pageNumber);
        printPageContent(firstIndexOnPage, lastIndexOnPage, localData);
        Console.WriteLine();
    }

    private void printPageHeader(int pageNumber)
    {
        Console.WriteLine(_pageHeader + pageNumber);
        Console.WriteLine();
    }
    
    private void printPageContent(int firstIndexOnPage, int lastIndexOnPage, int[] localData)
    {
        var firstIndexOfLastRowOnPage = firstIndexOnPage + _rowsPerPage - 1;
        for (var firstIndexInRow = firstIndexOnPage; firstIndexInRow <= firstIndexOfLastRowOnPage; firstIndexInRow++)
        {
            printRow(firstIndexInRow, lastIndexOnPage, localData);
        }
        Console.WriteLine();
    }

    private void printRow(int firstIndexInRow, int lastIndexInRow, int[] localData)
    {
        for (var column = 0; column < _columnsPerPage; column++)
        {
            var index = firstIndexInRow + column * _rowsPerPage;
            if (index < lastIndexInRow)
            {
                Console.Write("{0,10}", localData[index]);
            }
        }
        Console.WriteLine();
    }
}