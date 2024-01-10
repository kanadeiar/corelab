namespace ConsoleApp1;

public class Refactoring
{
    public int Gamma(int inputVal, int quantity, int yearToDate)
    {
        var importantValue1 = (inputVal * quantity) + delta();
        var importantValue2 = (inputVal * yearToDate) + 100;
        if (yearToDate - importantValue1 > 100)
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