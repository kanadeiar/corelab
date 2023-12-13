namespace ConsoleApp1;

public static class PrimeGenerator
{
    public static IEnumerable<int> Generate(int numberOfPrimes)
    {
        int ORDMAX = 30;
        int[] P = new int[numberOfPrimes + 1];
        int J = 1;
        int K = 1;
        int SQUARE = 9;
        int ORD = 2;
        int[] MULT = new int[ORDMAX + 1];
        bool JPRIME = false;
        int N;

        while (K < numberOfPrimes)
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
                        MULT[N] = MULT[N] + P[N] + P[N];
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
        P[1] = 2;
        return P;
    }
}