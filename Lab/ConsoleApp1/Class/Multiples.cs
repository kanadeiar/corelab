namespace ConsoleApp1.Class;

public class Multiples(int[] primes)
{
    private List<int> _multiplesOfPrimeFactors = new List<int>();

    public void AddMultiple(int multiple)
    {
        _multiplesOfPrimeFactors.Add(multiple);
    }

    public bool IsNextLargerAdd(int candidate)
    {
        var nextLargeNumber = primes[_multiplesOfPrimeFactors.Count];
        var largeMultiple = nextLargeNumber * nextLargeNumber;
        if (candidate == largeMultiple)
        {
            _multiplesOfPrimeFactors.Add(largeMultiple);
            return true;
        }
        return false;
    }

    public void GrowMultiples(int candidate)
    {
        for (var n = 0; n < _multiplesOfPrimeFactors.Count; n++)
        {
            var multiple = _multiplesOfPrimeFactors[n];
            while (multiple < candidate)
            {
                multiple += primes[n] * 2;
            }
            _multiplesOfPrimeFactors[n] = multiple;
        }
    }

    public bool IsAllNotEqual(int candidate)
    {
        return _multiplesOfPrimeFactors.All(multiple => candidate != multiple);
    }
}