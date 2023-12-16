namespace ConsoleApp1.Class;

public class PrimePrinter
{
    public void PrintPrimes()
    {
        int M = 1000;
        int RR = 50;
        int CC = 4;
        int ORDMAX = 30;
        int[] P = new int[M + 1];
        int C;
        int J = 1;
        int K = 1;
        bool JPRIME;
        int ORD = 2;
        int SQUARE = 9;
        int N;
        int[] MULT = new int[ORDMAX + 1];

        P[1] = 2;

        while (K < M)
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

        int PAGENUMBER = 1;
        int PAGEOFFSET = 1;
        int ROWOFFSET;
        while (PAGEOFFSET <= M)
        {
            Console.WriteLine("The First " + M + " Prime Numbers --- Page " + PAGENUMBER);
            Console.WriteLine();
            for (ROWOFFSET = PAGEOFFSET; ROWOFFSET < PAGEOFFSET + RR; ROWOFFSET++)
            {
                for (C = 0; C < CC; C++)
                {
                    if (ROWOFFSET + C * RR <= M)
                    {
                        Console.Write("{0,10}", P[ROWOFFSET + C * RR]);
                    }
                }
                Console.WriteLine();
            }
            PAGENUMBER++;
            PAGEOFFSET += RR * CC;
        }
    }
}