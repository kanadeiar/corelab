namespace ConsoleApp1.Class;

public class PrimeGenerator(int countOfPrimes)
{
    private int[] _primes;
    private int[] _multiplesOfPrimeFactors;

    public IEnumerable<int> Generate()
    {
        _primes = new int[countOfPrimes + 1];
        int ORDMAX = 30;
        _multiplesOfPrimeFactors = new int[ORDMAX + 1];
        set2AsFirstPrime();
        checkOddNumbersForSubsequentPrimes();
        return _primes;
    }

    private void set2AsFirstPrime()
    {
        _primes[1] = 2;
    }

    private void checkOddNumbersForSubsequentPrimes()
    {
        int primeIndex = 1;

        int J = 1;
        bool JPRIME;
        int ORD = 2;
        int SQUARE = 9;
        int N;
        while (primeIndex < countOfPrimes)
        {
            do
            {
                J += 2;
                if (J == SQUARE)
                {
                    ORD++;
                    SQUARE = _primes[ORD] * _primes[ORD];
                    _multiplesOfPrimeFactors[ORD - 1] = J;
                }

                N = 2;
                JPRIME = true;
                while (N < ORD && JPRIME)
                {
                    while (_multiplesOfPrimeFactors[N] < J)
                    {
                        _multiplesOfPrimeFactors[N] += _multiplesOfPrimeFactors[N] + _primes[N] * 2;
                    }

                    if (_multiplesOfPrimeFactors[N] == J)
                    {
                        JPRIME = false;
                    }

                    N++;
                }
            } while (!JPRIME);

            primeIndex++;
            _primes[primeIndex] = J;
        }
    }


}