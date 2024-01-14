using System.Diagnostics;

namespace ConsoleApp1;

public class Refactoring
{
    public int Calc(DateTime date)
    {
        int charge;
        if (notSummer(date))
            charge = summerCharge();
        else
            charge = winterCharge();

        return charge;
    }

    private static bool notSummer(DateTime date)
    {
        return date.Month >= 6 && date.Month <= 8;
    }

    private static int summerCharge()
    {
        return 1 * 232 + 1988;
    }

    private static int winterCharge()
    {
        return 3 * 60;
    }
}