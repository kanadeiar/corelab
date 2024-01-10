namespace ConsoleApp1;

internal class gamma
{
    private readonly Refactoring _refactoring;
    private int _yearToDate;
    private int _quantity;
    private int _inputVal;

    public gamma(Refactoring refactoring, int inputVal, int quantity, int yearToDate)
    {
        _refactoring = refactoring;
        _inputVal = inputVal;
        _quantity = quantity;
        _yearToDate = yearToDate;
    }

    public int Calculate()
    {
        var importantValue1 = _inputVal * _quantity + delta();
        var importantValue2 = _inputVal * _yearToDate + 100;
        if (_yearToDate - importantValue1 > 100)
        {
            importantValue1 -= 20;
        }

        var importantValue3 = importantValue1 * 7;
        return importantValue3 - 2 * importantValue2;
    }

    private int delta()
    {
        return 1;
    }
}