namespace ConsoleApp1.Class;

public class PrimeGenerator(int countOfPrimes)
{
    private int[] _primes;
    private Multiples _multiples;

    public IEnumerable<int> Generate()
    {
        _primes = new int[countOfPrimes];
        _multiples = new Multiples(_primes);
        setupFirstPrime();
        addPrimeNumbers();
        return _primes;
    }

    private void setupFirstPrime()
    {
        _primes[0] = 2;
        _multiples.AddMultiple(2);
    }

    private void addPrimeNumbers()
    {
        int primeIndex = 1;
        for (var candidate = 3; primeIndex < countOfPrimes; candidate += 2)
        {
            if (isPrime(candidate))
            {
                _primes[primeIndex++] = candidate;
            }
        }
    }

    private bool isPrime(int candidate)
    {
        if (_multiples.IsNextLargerAdd(candidate))
        {
            return false;
        }

        _multiples.GrowMultiples(candidate);
        if (_multiples.IsAllNotEqual(candidate))
        {
            return true;
        }
        return false;
    }
}