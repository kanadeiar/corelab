namespace ConsoleApp1.Class;

public class PrimeGenerator
{
    private readonly int _countOfPrimes;

    public PrimeGenerator(int countOfPrimes)
    {
        _countOfPrimes = countOfPrimes;
    }

    public IEnumerable<int> Generate()
    {
        int ORDMAX = 30;
        int[] P = new int[_countOfPrimes + 1];
        int J = 1;
        int K = 1;
        bool JPRIME;
        int ORD = 2;
        int SQUARE = 9;
        int N;
        int[] MULT = new int[ORDMAX + 1];
        P[1] = 2;

        while (K < _countOfPrimes)
        {
            do
            {
                J += 2;
                if (J == SQUARE)
                {
                    ORD++;
                    SQUARE = P[ORD] * P[ORD];
                    MULT[ORD - 1] = J;
                }
                N = 2;
                JPRIME = true;
                while (N < ORD && JPRIME)
                {
                    while (MULT[N] < J)
                    {
                        MULT[N] += MULT[N] + P[N] * 2;
                    }
                    if (MULT[N] == J)
                    {
                        JPRIME = false;
                    }
                    N++;
                }
            } while (!JPRIME);
            K++;
            P[K] = J;
        }

        return P;
    }
}