using Newtonsoft.Json.Serialization;

namespace ConsoleApp1;

public class Refactoring
{
    public int Gamma(int inputVal, int quantity, int yearToDate)
    {
        return new gamma(this, inputVal, quantity, yearToDate).Calculate();
    }
}