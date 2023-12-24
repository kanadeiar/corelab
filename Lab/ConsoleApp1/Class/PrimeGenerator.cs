namespace ConsoleApp1.Class;

public class PrimeGenerator(int countOfPrimes)
{
    private int[] _primes;
    private int[] _multiplesOfPrimeFactors;

    public IEnumerable<int> Generate()
    {
        _primes = new int[countOfPrimes];
        int ORDMAX = 30;
        _multiplesOfPrimeFactors = new int[ORDMAX + 1];
        setupFirstPrime();
        addPrimeNumbers();
        return _primes;
    }

    private void setupFirstPrime()
    {
        _primes[0] = 2;
        _multiplesOfPrimeFactors[1] = 2;
    }

    private void addPrimeNumbers()
    {
        int primeIndex = 1;

        int ORD = 2;
        int SQUARE = 9;
        
        for (var candidate = 3; primeIndex < countOfPrimes; candidate += 2)
        {
            if (candidate == SQUARE)
            {
                ORD++;
                SQUARE = _primes[ORD - 1] * _primes[ORD - 1];
                _multiplesOfPrimeFactors[ORD - 1] = candidate;
            }

            var N = 1;
            var JPRIME = true;
            while (N < ORD && JPRIME)
            {
                while (_multiplesOfPrimeFactors[N] < candidate)
                {
                    _multiplesOfPrimeFactors[N] += _multiplesOfPrimeFactors[N] + _primes[N - 1] * 2;
                }

                if (_multiplesOfPrimeFactors[N] == candidate)
                {
                    JPRIME = false;
                }

                N++;
            }

            if (JPRIME)
            {
                _primes[primeIndex++] = candidate;
            }
        }
    }


}