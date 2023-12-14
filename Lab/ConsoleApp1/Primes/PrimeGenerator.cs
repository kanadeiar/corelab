namespace ConsoleApp1.Primes;

public static class PrimeGenerator
{
    private static int[] _primes;
    private static List<int> _multiplesOfPrimeFactors;

    public static IEnumerable<int> Generate(int numberOfPrimes)
    {
        _primes = new int[numberOfPrimes];
        _multiplesOfPrimeFactors = new List<int>();
        set2AsFirstPrime();
        checkOddNumbersForSubsequentPrimes();
        return _primes;
    }

    private static void set2AsFirstPrime()
    {
        _primes[0] = 2;
        _multiplesOfPrimeFactors.Add(2);
    }

    private static void checkOddNumbersForSubsequentPrimes()
    {
        var primeIndex = 1;
        for (int candidate = 3; primeIndex < _primes.Length; candidate += 2)
        {
            if (isPrime(candidate))
            {
                _primes[primeIndex++] = candidate;
            }
        }
    }

    private static bool isPrime(int candidate)
    {
        if (isLeast(candidate))
        {
            _multiplesOfPrimeFactors.Add(candidate);
            return false;
        }
        return isNotMultiple(candidate);
    }

    private static bool isLeast(int candidate)
    {
        var nextLargerPrimeFactor = _primes[_multiplesOfPrimeFactors.Count];
        var leastRelevantMultiple = nextLargerPrimeFactor * nextLargerPrimeFactor;
        return candidate == leastRelevantMultiple;
    }

    private static bool isNotMultiple(int candidate)
    {
        for (int i = 0; i < _multiplesOfPrimeFactors.Count; i++)
        {
            if (isMultipleOfNthPrimeFactor(candidate, i))
            {
                return false;
            }
        }
        return true;
    }

    private static bool isMultipleOfNthPrimeFactor(int candidate, int n)
    {
        return candidate == smallestOddNthMultipleNotLessThanCandidate(candidate, n);
    }

    private static int smallestOddNthMultipleNotLessThanCandidate(int candidate, int n)
    {
        var multiple = _multiplesOfPrimeFactors[n];
        while (multiple < candidate)
        {
            multiple += 2 * _primes[n];
        }
        _multiplesOfPrimeFactors[n] = multiple;
        return multiple;
    }
}